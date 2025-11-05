namespace AES_GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblInputHex = new System.Windows.Forms.Label();
            this.txtInputHex = new System.Windows.Forms.TextBox();
            this.chkUseNative = new System.Windows.Forms.CheckBox();
            this.txtNativePath = new System.Windows.Forms.TextBox();
            this.btnBrowseNative = new System.Windows.Forms.Button();
            this.chkUseWSL = new System.Windows.Forms.CheckBox();
            this.groupMode = new System.Windows.Forms.GroupBox();
            this.rdoEncrypt = new System.Windows.Forms.RadioButton();
            this.rdoDecrypt = new System.Windows.Forms.RadioButton();
            this.btnExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 15);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(31, 15);
            this.lblKey.TabIndex = 0;
            this.lblKey.Text = "Chave";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(60, 12);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(300, 23);
            this.txtKey.TabIndex = 1;
            this.txtKey.Text = "0123456789abcdef";
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(12, 48);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(47, 15);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "Entrada";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(60, 45);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(300, 23);
            this.txtInput.TabIndex = 3;
            this.txtInput.Text = "mensagem12345678";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(60, 90);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(100, 27);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "Encriptar";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(260, 90);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(100, 27);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Decriptar (hex)";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(60, 140);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(300, 120);
            this.txtOutput.TabIndex = 6;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(12, 143);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(39, 15);
            this.lblOutput.TabIndex = 7;
            this.lblOutput.Text = "Saída";
            // 
            // lblInputHex
            // 
            this.lblInputHex.AutoSize = true;
            this.lblInputHex.Location = new System.Drawing.Point(12, 75);
            this.lblInputHex.Name = "lblInputHex";
            this.lblInputHex.Size = new System.Drawing.Size(36, 15);
            this.lblInputHex.TabIndex = 8;
            this.lblInputHex.Text = "Hex in";
            // 
            // txtInputHex
            // 
            this.txtInputHex.Location = new System.Drawing.Point(60, 72);
            this.txtInputHex.Name = "txtInputHex";
            this.txtInputHex.Size = new System.Drawing.Size(300, 23);
            this.txtInputHex.TabIndex = 9;
            this.txtInputHex.Text = "";
            // 
            // chkUseNative
            // 
            this.chkUseNative.AutoSize = true;
            this.chkUseNative.Location = new System.Drawing.Point(12, 270);
            this.chkUseNative.Name = "chkUseNative";
            this.chkUseNative.Size = new System.Drawing.Size(122, 19);
            this.chkUseNative.TabIndex = 10;
            this.chkUseNative.Text = "Usar binário nativo";
            this.chkUseNative.UseVisualStyleBackColor = true;
            // 
            // txtNativePath
            // 
            this.txtNativePath.Location = new System.Drawing.Point(140, 268);
            this.txtNativePath.Name = "txtNativePath";
            this.txtNativePath.Size = new System.Drawing.Size(160, 23);
            this.txtNativePath.TabIndex = 11;
            // 
            // btnBrowseNative
            // 
            this.btnBrowseNative.Location = new System.Drawing.Point(305, 267);
            this.btnBrowseNative.Name = "btnBrowseNative";
            this.btnBrowseNative.Size = new System.Drawing.Size(55, 25);
            this.btnBrowseNative.TabIndex = 12;
            this.btnBrowseNative.Text = "...";
            this.btnBrowseNative.UseVisualStyleBackColor = true;
            this.btnBrowseNative.Click += new System.EventHandler(this.btnBrowseNative_Click);
            // 
            // chkUseWSL
            // 
            this.chkUseWSL.AutoSize = true;
            this.chkUseWSL.Location = new System.Drawing.Point(12, 295);
            this.chkUseWSL.Name = "chkUseWSL";
            this.chkUseWSL.Size = new System.Drawing.Size(124, 19);
            this.chkUseWSL.TabIndex = 13;
            this.chkUseWSL.Text = "Executar via WSL";
            this.chkUseWSL.UseVisualStyleBackColor = true;
            // 
            // groupMode
            // 
            this.groupMode.Controls.Add(this.rdoEncrypt);
            this.groupMode.Controls.Add(this.rdoDecrypt);
            this.groupMode.Location = new System.Drawing.Point(12, 115);
            this.groupMode.Name = "groupMode";
            this.groupMode.Size = new System.Drawing.Size(348, 48);
            this.groupMode.TabIndex = 14;
            this.groupMode.TabStop = false;
            this.groupMode.Text = "Modo";
            // 
            // rdoEncrypt
            // 
            this.rdoEncrypt.AutoSize = true;
            this.rdoEncrypt.Location = new System.Drawing.Point(15, 20);
            this.rdoEncrypt.Name = "rdoEncrypt";
            this.rdoEncrypt.Size = new System.Drawing.Size(74, 19);
            this.rdoEncrypt.TabIndex = 0;
            this.rdoEncrypt.TabStop = true;
            this.rdoEncrypt.Text = "Encriptar";
            this.rdoEncrypt.UseVisualStyleBackColor = true;
            this.rdoEncrypt.CheckedChanged += new System.EventHandler(this.ModeChanged);
            // 
            // rdoDecrypt
            // 
            this.rdoDecrypt.AutoSize = true;
            this.rdoDecrypt.Location = new System.Drawing.Point(120, 20);
            this.rdoDecrypt.Name = "rdoDecrypt";
            this.rdoDecrypt.Size = new System.Drawing.Size(80, 19);
            this.rdoDecrypt.TabIndex = 1;
            this.rdoDecrypt.TabStop = true;
            this.rdoDecrypt.Text = "Descript.";
            this.rdoDecrypt.UseVisualStyleBackColor = true;
            this.rdoDecrypt.CheckedChanged += new System.EventHandler(this.ModeChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(160, 270);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 27);
            this.btnExecute.TabIndex = 15;
            this.btnExecute.Text = "Executar";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 350);
            this.Controls.Add(this.chkUseWSL);
            this.Controls.Add(this.btnBrowseNative);
            this.Controls.Add(this.txtNativePath);
            this.Controls.Add(this.chkUseNative);
            this.Controls.Add(this.groupMode);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtInputHex);
            this.Controls.Add(this.lblInputHex);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AES GUI - 128 bits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblInputHex;
        private System.Windows.Forms.TextBox txtInputHex;
        private System.Windows.Forms.CheckBox chkUseNative;
        private System.Windows.Forms.TextBox txtNativePath;
        private System.Windows.Forms.Button btnBrowseNative;
        private System.Windows.Forms.CheckBox chkUseWSL;
        private System.Windows.Forms.GroupBox groupMode;
        private System.Windows.Forms.RadioButton rdoEncrypt;
        private System.Windows.Forms.RadioButton rdoDecrypt;
        private System.Windows.Forms.Button btnExecute;
    }
}
