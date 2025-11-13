# Disciplina: Tecnologias Emergentes - 2025 - 6º Período da UniAlfa

![Badge](https://img.shields.io/badge/Marcos%20Dias%20Vendramini-ASP.NET%20C%23-red)

## Gerando relatórios sobre a cobertura de testes do projeto

### Pacotes para adicionar no projeto de testes
- coverlet.collector
- coverlet.msbuild

### Comando do terminal para gerar o relatorio do percentual
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput=coverage.opencover.xml

### Comando para instalar o ReportGenerator
dotnet tool install --tool-path tools dotnet-reportgenerator-globaltool --version 4.6.1

### Comando para gerar o relatório detalhado com o ReportGenerator
reportgenerator -reports:C:\Users\marco\source\repos\MeusLivros\MeusLivros.Tests\coverage.opencover.xml -targetdir:coverage_report

### Tecnologias

As seguintes ferramentas foram usadas na construção dos projetos:

- [Coverlet](https://github.com/coverlet-coverage/coverlet)
- [ReportGenerator](https://github.com/danielpalme/ReportGenerator)
