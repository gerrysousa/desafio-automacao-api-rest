# desafio-automacao-api-rest
Projeto para desafio e aprendizado sobre automação de APIs REST

**Regras/Metas**

- [x]	1) Implementar 50 scripts de testes que manipulem uma aplicação cuja interface é uma API REST. 
- [x]	2) Alguns scripts devem ler dados de uma planilha Excel para implementar Data-Driven. 
- [x]	3) Notem que 50 scripts podem cobrir mais de 50 casos de testes se usarmos Data-Driven. Em outras palavras, implementar 50 CTs usando data-driven não é a mesma coisa que implementar 50 scripts. 
- [x]	4) O projeto deve tratar autenticação. Exemplo: OAuth2. 
- [x]	5) Pelo menos um teste deve fazer a validação usando REGEX (Expressões Regulares). 
- [x]	6) Pelo menos um script deve usar código Groovy / Node.js ou outra linguagem para fazer scripts. Exemplos: ( Para reutilizar um passo de outro teste; ○ Para calcular o CPF; ○ Iterar em uma lista de valores retornados em uma chamada; Fazer asserts.)
- [x]	7) O projeto deverá gerar um relatório de testes automaticamente. 
- [x]	8) Implementar pelo menos dois ambientes (desenvolvimento / homologação) 
- [X]	9) A massa de testes deve ser preparada neste projeto, seja com scripts carregando massa nova no BD ou com restore de banco de dados. (Se usar WireMock ( http://wiremock.org/ ) a massa será tratada implicitamente.)
- [x]	10) Executar testes em paralelo. Pelo menos duas threads (25 testes cada). 
- [x]	11) Testes deverão ser agendados pelo Jenkins, CircleCI, TFS ou outra ferramenta de CI que preferir. 

------------------------------
- Os Relatórios do projeto são montados com o ExtentReport.
- Os testes foram agendados no Azure DevOps (o Arquivo com a configuração se encontra no repositório (/DesafioAutomacaoApiRest/Resources/Configuracao_Azure_Devops.pdf)
-------------------------------
- Link com a execução no Azure DevOps: https://dev.azure.com/gerrycon/Projeto%20Testes%20API%20Rest/_build/results?buildId=44&view=ms.vss-test-web.build-test-results-tab

