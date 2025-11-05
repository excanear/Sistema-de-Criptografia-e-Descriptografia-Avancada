GUI C# para AES-Encryption

O projeto `gui_cs` contém um aplicativo Windows Forms (C#) que permite encriptar e decriptar blocos de 16 bytes (AES-128) usando a implementação gerenciada do .NET (System.Security.Cryptography.Aes).

Requisitos:
- .NET SDK 7.0 ou superior (ou adapte o TargetFramework no .csproj para a versão instalada)

Como compilar e executar:

Abra um terminal na pasta `gui_cs` e execute:

```powershell
cd "C:\Users\Henry\OneDrive\Área de Trabalho\Sistema de Criptografia e Descriptografia Avançada\AES-Encryption\gui_cs"
# build
dotnet build
# executar
dotnet run --project .
```

Uso:
- Informe a `Chave` (16 caracteres ASCII) — se menor que 16, será preenchida com espaços; se maior, será truncada.
- Para encriptar: coloque texto ASCII de 16 bytes em `Entrada` e clique em `Encriptar`.
- Para decriptar: insira os 16 bytes cifrados em `Hex in` no formato hex separado por espaços (ex.: `4C 46 9F B6 2D 7A 9B 90 B7 DF FC B3 28 A5 15 3A`) e clique em `Decriptar (hex)`.

Observações:
- O app usa AES em modo ECB sem padding para encriptação/decriptação de blocos únicos de 16 bytes, para ficar compatível com o comportamento do exe original (quando usa blocos). Ajuste conforme necessário para modos/formatos diferentes.
- Se você preferir que o GUI invoque o executável nativo (implementação em assembly), posso adicionar essa opção — para isso preciso confirmar a interface de I/O do binário. Atualmente o GUI usa o AES gerenciado do .NET para garantir que funcione sem dependências externas.
