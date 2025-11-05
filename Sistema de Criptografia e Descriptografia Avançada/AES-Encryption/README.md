# AES Encryption (implementação em x86 Assembly)

Implementação do AES-128 (cifra Rijndael) em assembly x86. Este repositório contém a implementação das rotinas de encriptação e decriptação, arquivos de inclusão com S-Boxes, geração de round keys, mix columns, e um pequeno I/O/Socket para testes.

Este README está em Português (pt-BR) e explica como compilar, executar e testar o projeto em ambientes Linux e Windows (via WSL ou ferramentas compatíveis).

## Requisitos
- `nasm` (assembler NASM)
- `make` (ou `mingw32-make`/`gmake` no Windows, ou usar WSL)
- Um linker/ambiente compatível (em Linux, o `ld`/`gcc` disponibiliza o linking necessário)

Instale com o gerenciador de pacotes da sua plataforma. Exemplos:

- Debian/Ubuntu (Linux):
```
sudo apt update && sudo apt install -y nasm make build-essential
```
- Arch Linux:
```
sudo pacman -S nasm make base-devel
```
- Windows (opções):
  - Recomendado: usar WSL (Windows Subsystem for Linux) e instalar `nasm` e `make` dentro do WSL.
  - Ou instalar via Chocolatey (PowerShell como Administrador):
```
choco install nasm make -y
```
  - Se usar MinGW/MSYS, instale `nasm` e `mingw32-make` e ajuste o PATH. Pode ser necessário adaptar o `makefile`.

## Como compilar
Abra um terminal na pasta do repositório (`AES-Encryption`) e execute:

```
make
```

Isso deve montar e linkar o executável `AES-Encryption` (ou equivalente) na mesma pasta. Se o `make` falhar no Windows, tente no WSL ou adapte para `mingw32-make`.

## Como executar
Uso geral (linha de comando):

```
./AES-Encryption
```

### Entrada/saída básica
- Modo de encriptação: informe a chave (16 bytes ASCII) e a mensagem (16 bytes ASCII). O programa retorna a mensagem encriptada como uma matriz 4x4 de bytes hexadecimais.
- Modo de decriptação: informe a mensagem encriptada como 16 bytes hex (ex.: `4c 46 9f b6 ...`) e a chave (16 bytes ASCII) — o programa retorna a mensagem original.

Exemplo (conceitual):

Chave (16 bytes ASCII): "0123456789abcdef"
Mensagem (16 bytes ASCII): "mensagem12345678"

Saída (matriz 4x4 hex):

```
0x4c 0x46 0x9f 0xb6
0x2d 0x7a 0x9b 0x90
0xb7 0xdf 0xfc 0xb3
0x28 0xa5 0x15 0x3a
```

Observação: os detalhes exatos do formato de I/O (ordem de bytes, prompts) estão no código-fonte; ver `IO.inc` e `AES-Encryption.asm` para comportamento preciso.

## Modo servidor (WIP)
O repositório contém suporte experimental para executar o binário como um servidor TCP (passar a porta como argumento). Essa funcionalidade está marcada como WIP (work in progress). Use com cautela.

Exemplo (rodar servidor na porta 9001):

```
./AES-Encryption 9001
```

## Estrutura principal do repositório
- `AES-Encryption.asm` — arquivo principal com a rotina de execução
- `Encryption.inc` / `Decryption.inc` — rotinas de criptografia e descriptografia
- `RoundKey.inc`, `SBOX.inc`, `SBOXInverse.inc`, `Rotation.inc`, `ColumnMixing.inc` — helpers do AES
- `IO.inc` — rotinas de entrada/saída
- `Socket.inc` — código para comunicação em rede (servidor/cliente)
- `makefile` — regras para compilação
- `LICENSE` — licença do projeto

## Testes rápidos
1. Compile com `make`.
2. Execute o binário e siga os prompts para fornecer chave e mensagem.
3. Compare saída encriptada e teste a decriptação com os bytes retornados.

Se preferir, crie pequenos wrappers em Python/PowerShell para automatizar testes usando sockets (se estiver usando o modo servidor).

## Contribuição
Pull requests são bem-vindos. Antes de enviar PRs, por favor:
- Abra uma issue descrevendo a mudança ou bug.
- Mantenha o assembly e o estilo consistente com os arquivos existentes.

## Créditos e referências
Implementação original: autor do repositório original (veja histórico do GitHub).

Recursos para entender AES:
- AES Explained (Computerphile): https://youtu.be/O4xNJsjtN6E
- Animação explicativa do Rijndael: https://youtu.be/gP4PqVGudtg

## Licença
Veja o arquivo `LICENSE` neste repositório.
