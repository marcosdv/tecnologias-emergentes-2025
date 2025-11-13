# Disciplina: Programação Avançada Para Web - 2022 - 6º Período da UniAlfa

![Badge](https://img.shields.io/badge/Marcos%20Dias%20Vendramini-ASP.NET%20C%23-red)

## Instalando o Entity Framework

### Instalação do dotnet-ef command line tools
dotnet tool install --global dotnet-ef

### Comando para gerar as Migrations
dotnet ef migrations add CriacaoInicial -s ..\MeusLivros.Api\MeusLivros.Api.csproj

### Comando para atualizar o banco de dados de acordo com as migrations
dotnet ef database update -s ..\MeusLivros.Api\MeusLivros.Api.csproj

### Comando para gerar o script do banco de dados, para casos de não houver acesso direto ao banco (ex: banco de produção)
dotnet ef migrations script -o ./script.sql

### Tecnologias

As seguintes ferramentas foram usadas na construção dos projetos:

- [Entity Framework](https://docs.microsoft.com/pt-br/ef/)