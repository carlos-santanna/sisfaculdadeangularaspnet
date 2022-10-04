# Sistema de Gerenciamento de Faculdade #

Esse sistema foi desenvolvido como exercício técnico.

## Pré-requisitos para execução do projeto

- Dotnet SDK - é necessário baixar e instalar o Dotnet SDK do site da microsoft (https://dotnet.microsoft.com/en-us/download) para o sistema operacional desejado;

Esse processo foi executadono Windows e utilizando o sdk do dotnet core na versão 5.0
[https://download.visualstudio.microsoft.com/download/pr/14ccbee3-e812-4068-af47-1631444310d1/3b8da657b99d28f1ae754294c9a8f426/dotnet-sdk-5.0.408-win-x64.exe] (https://download.visualstudio.microsoft.com/download/pr/14ccbee3-e812-4068-af47-1631444310d1/3b8da657b99d28f1ae754294c9a8f426/dotnet-sdk-5.0.408-win-x64.exe)
Após o download, efetue o processo de instalação seguindo os passos demonstrados no instalador do sdk.


- Nodejs - A aplicação foi desenvolvida utilizando o node na versão 16.17.1 e seguiu o processo de isntalação padrão. 
Link do instalador para windows:
[https://nodejs.org/dist/v16.17.1/node-v16.17.1-x64.msi] (https://nodejs.org/dist/v16.17.1/node-v16.17.1-x64.msi)
Em caso de necessidade de instalação em outros sistemas operacionais utilize acesse o site [https://nodejs.org/en/download/] (https://nodejs.org/en/download/) e efetue o downalod para o sistema operacional desejado.

- Caso esteja utilizando Windows, a execução de scripts está desabilitada por default no Power Shell, desse modo, execute o comando abaixo no Power Sheel, de modo a permitir a execução do script no angular.

Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned

- Instale o Angular 14
Se você estiver no Windows (principalmente nas versões mais novas), será necessário executar esse comando no Prompt de Comandos do Windows (CMD) - o Power Shell possuí algumas restrições de segurança e caso não seja tratada o script poderá falh

- npm install -g @angular/cli@14.2.4



execute o arquivo start.bat na raiz do projeto


## Caso necessário

acesse o diretorio SisFaculdadeApi e execute o comando:
- dotnet run

acesse o diretorio SisFaculdadeWeb e execute o comando

- npm install

- ng serve

