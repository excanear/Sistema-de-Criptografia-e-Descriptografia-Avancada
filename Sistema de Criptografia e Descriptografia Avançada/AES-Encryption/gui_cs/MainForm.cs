using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace AES_GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var keyText = txtKey.Text ?? string.Empty;
            var inputText = txtInput.Text ?? string.Empty;

            try
            {
                var key = GetFixedBytes(keyText, 16);
                var block = GetFixedBytes(inputText, 16);
                var cipher = AES_Block_Encrypt(key, block);

                txtOutput.Text = ToMatrixHex(cipher);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            var keyText = txtKey.Text ?? string.Empty;
            var inputHex = txtInputHex.Text ?? string.Empty;

            try
            {
                if (chkUseNative.Checked)
                {
                    var res = RunNativeProcess("decrypt", keyText, inputHex);
                    txtOutput.Text = res;
                    return;
                }

                var key = GetFixedBytes(keyText, 16);
                var cipher = ParseHexBytes(inputHex);
                if (cipher.Length != 16) throw new ArgumentException("Dados encriptados devem conter exatamente 16 bytes (32 hex).");

                var plain = AES_Block_Decrypt(key, cipher);
                txtOutput.Text = Encoding.ASCII.GetString(plain);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helpers
        private static byte[] AES_Block_Encrypt(byte[] key, byte[] block)
        {
            using var aes = Aes.Create();
            aes.KeySize = 128;
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;

            using var encryptor = aes.CreateEncryptor();
            return encryptor.TransformFinalBlock(block, 0, block.Length);
        }

        private static byte[] AES_Block_Decrypt(byte[] key, byte[] block)
        {
            using var aes = Aes.Create();
            aes.KeySize = 128;
            aes.Key = key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.None;

            using var decryptor = aes.CreateDecryptor();
            return decryptor.TransformFinalBlock(block, 0, block.Length);
        }

        private static byte[] GetFixedBytes(string text, int length)
        {
            // Use ASCII bytes. If shorter, pad with spaces; if longer, truncate.
            var bytes = Encoding.ASCII.GetBytes(text);
            if (bytes.Length == length) return bytes;
            var outb = new byte[length];
            Array.Clear(outb, 0, length);
            Array.Copy(bytes, outb, Math.Min(bytes.Length, length));
            for (int i = bytes.Length; i < length; i++) outb[i] = (byte) ' ';
            return outb;
        }

        private static string ToMatrixHex(byte[] data)
        {
            // Print as 4x4 matrix column-major as in AES
            if (data == null) return string.Empty;
            var sb = new StringBuilder();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int idx = col * 4 + row;
                    sb.AppendFormat("0x{0:X2}", data[idx]);
                    if (col < 3) sb.Append(" ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private static byte[] ParseHexBytes(string hex)
        {
            // Accept hex with spaces or commas
            var tokens = hex.Split(new[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var bytes = tokens.Select(t => Convert.ToByte(t.Trim(), 16)).ToArray();
            return bytes;
        }

        private void btnBrowseNative_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Title = "Selecione o binário nativo";
            dlg.Filter = "Executáveis|*.exe;*|All files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtNativePath.Text = dlg.FileName;
            }
        }

        private void ModeChanged(object sender, EventArgs e)
        {
            // Enable/disable input fields depending on mode
            if (rdoEncrypt.Checked)
            {
                txtInput.Enabled = true;
                txtInputHex.Enabled = false;
                txtInputHex.Text = string.Empty;
            }
            else
            {
                txtInput.Enabled = false;
                txtInputHex.Enabled = true;
                txtInput.Text = string.Empty;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoEncrypt.Checked)
                {
                    // Use native if requested
                    if (chkUseNative.Checked)
                    {
                        var res = RunNativeProcess("encrypt", txtKey.Text ?? string.Empty, txtInput.Text ?? string.Empty);
                        txtOutput.Text = res;
                        return;
                    }

                    // Managed encrypt
                    var key = GetFixedBytes(txtKey.Text ?? string.Empty, 16);
                    var block = GetFixedBytes(txtInput.Text ?? string.Empty, 16);
                    var cipher = AES_Block_Encrypt(key, block);
                    txtOutput.Text = ToMatrixHex(cipher);
                }
                else
                {
                    // Decrypt
                    if (chkUseNative.Checked)
                    {
                        var res = RunNativeProcess("decrypt", txtKey.Text ?? string.Empty, txtInputHex.Text ?? string.Empty);
                        txtOutput.Text = res;
                        return;
                    }

                    var key = GetFixedBytes(txtKey.Text ?? string.Empty, 16);
                    var cipher = ParseHexBytes(txtInputHex.Text ?? string.Empty);
                    if (cipher.Length != 16) throw new ArgumentException("Dados encriptados devem conter exatamente 16 bytes (32 hex).");
                    var plain = AES_Block_Decrypt(key, cipher);
                    txtOutput.Text = Encoding.ASCII.GetString(plain);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string RunNativeProcess(string mode, string keyText, string payload)
        {
            // mode: "encrypt" or "decrypt"; payload: message (ASCII) for encrypt or hex string for decrypt
            var binPath = txtNativePath.Text?.Trim();
            if (string.IsNullOrEmpty(binPath) || !System.IO.File.Exists(binPath))
                throw new InvalidOperationException("Caminho do binário nativo inválido ou não encontrado.");

            // Build stdin according to assembly protocol
            // encrypt: send '1\n' then message (16 bytes) + '\n' then key + '\n'
            // decrypt: send '2\n' then 16 hex bytes (pairs separated by spaces) + '\n' then key + '\n'
            var sbInput = new StringBuilder();
            if (mode == "encrypt")
            {
                sbInput.AppendLine("1");
                sbInput.AppendLine(payload); // message
                sbInput.AppendLine(keyText);
            }
            else
            {
                sbInput.AppendLine("2");
                sbInput.AppendLine(payload); // hex pairs
                sbInput.AppendLine(keyText);
            }

            var psi = new System.Diagnostics.ProcessStartInfo();
            if (chkUseWSL.Checked)
            {
                // Assume user provided WSL path to executable or a command usable inside WSL
                psi.FileName = "wsl.exe";
                psi.Arguments = $"{EscapeArgForWsl(binPath)}";
            }
            else
            {
                psi.FileName = binPath;
            }

            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            using var proc = new System.Diagnostics.Process();
            proc.StartInfo = psi;
            proc.Start();

            // write input
            proc.StandardInput.Write(sbInput.ToString());
            proc.StandardInput.Flush();
            proc.StandardInput.Close();

            // read all output
            var output = proc.StandardOutput.ReadToEnd();
            var err = proc.StandardError.ReadToEnd();
            proc.WaitForExit(3000);

            if (!string.IsNullOrEmpty(err))
            {
                // include stderr if present
                output += "\n[stderr] " + err;
            }

            // Parse output: for encrypt, look for 0x.. matrix; for decrypt, plain text
            return output.Trim();
        }

        private static string EscapeArgForWsl(string path)
        {
            // If path contains spaces, wrap in quotes; convert backslashes to forward slashes if probable WSL path
            if (path.Contains(" ")) path = '"' + path + '"';
            return path;
        }
    }
}
