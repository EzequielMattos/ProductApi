# API Produtos

Esse projeto foi criado com o objetivo de demonstrar meus conhecimentos em criação de aplicações API utilizando padrões de projetos e boas práticas.

## Componentes da solução

- Product.Api
  ●	No projeto .Api está armazenado a controller, que é responsavel por executar apenas as funcionalidades da nossa API de produtos, aonde faz a chamada dos services para execução dos endpoints. Além de conter também a configuração da nossa solution.
- Product.Application
  ● O projeto .Application tem como sua principal funcionalidade guardar o services que são chamados pelo nosso projeto .Api, e nele estão as nossas regras de negócio.
- Product.Domain 
  ● Já o projeto .Domain conta com a nossa entidade de produto e também as interfaces com os contratos.
- Product.Infrastructure
  ● Esse projeto conta com a parte de conexão com o banco de dados da nossa aplicação, desde o contexto até as partes que executam os scripts dentro do nosso banco de dados.
-Product.UnitTest
  ● E por fim a parte de teste da nossa aplicação, que se encontra alguns testes unitários importantes para verificar as funcionalidades da nossa aplicação.  

## Sobre as tecnoplogias utilizadas

- C# 10
- .NET 6
- ORM: Entity Framework
- SOLID
- Clean Architecture
- Database in Memory
- Swagger


## Autor

- [@github-ezequielMattos](https://github.com/EzequielMattos)
- [@linkedin-ezequielMattos](https://www.linkedin.com/in/ezequielmattos/) 

