# Excluir Videos "Assistir Mais Tarde" - YouTube

## O que é esse projeto?
Esse projeto trata-se de um robô, capaz de logar-se em uma conta do youtube e excluir vídeos pré-informados da playlist de "Assistir mais tarde".

## Por que criei esse projeto?
A minha forma pessoal de utilizar o youtube é guardando vários vídeos na playlist "*Assistir mais tarde*", e depois assistir de forma sequencial. Com isso, acabam ficando vários vídeos já vistos, misturados com outros que por algum motivo pulei no momento. A opção de excluir um por um pelo site ou aplicativo é muito demorada e cansativa, e por isso criei esse robô, onde informo somente os números dos vídeos que desejo excluir e o programa o faz automaticamente.

## Por que subi esse projeto em um repositório público?
Não acredito que esse projeto será útil para muitas pessoas em sua finalidade principal. Porém, pode ajudar outras pessoas que desejam conhecer um pouco mais das ferramentas utilizadas, assim, ele serve como uma base de estudos para qualquer um que deseje. Outro bom motivo também é servir de portfólio, pois apesar de ser um projeto pequeno, nele demonstro o uso de duas tecnologias importantes: C#/.net Core e Selênium.

## Quais foram as principais tecnologias utilizadas?
- C# 8.0
- .NET Core 3.0
- Selênium 3.141.0
- Visual Studio 2019 16.4.1

## Dependências do projeto
Além de restaurar os pacotes do Nuget, esse projeto depende que haja uma versão do ChromeDriver na pasta "*C:\SeleniumDrivers*". O ChromeDriver pode ser baixado [nesse link](https://chromedriver.chromium.org/downloads), e a versão deve coincidir com a versão do Chrome instalada na máquina. É possível adaptar o projeto para rodar em outros navegadores com pequenas modificações, mas a configuração atual necessita rodar no Google Chrome, portanto, ele também é uma dependência externa.

## Ops! Não está funcionando?
Enquanto terminava o projeto, o Youtube mudou um pouco a interface, e tive que refazer uma parte. Se o programa não estiver encontrando algum elemento, é provável que o Youtube tenha alterado sua interface novamente. Não me comprometo a atualizar esse projeto.
