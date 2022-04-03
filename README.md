# O que é a CidadeAltaAPI?
A CidadeAltaAPI é uma API para controlar os códigos penais da cidade. Nesta API é possível que o usuário se autentique e após o sucesso poderá consultar, incluir, editar e visualizar os códigos penais da Cidade Alta.

# Rodando o projeto no Visual Studio 2022:
Abra o Package Manager Console, selecione o projeto `CidadeAlta.Data` e rode o comando `Update-Database`. Isso irá criar o banco de dados MySQL  
<img src="https://i.imgur.com/DQL6Yun.png"/>  
Execute o projeto `CidadeAlta.API`

# Tecnologias utilizadas:
- ASP.NET 6.0
- ASP.NET WebApi Core com autenticação JWT Bearer
- Entity Framework Core 6
- Injeção de dependências nativa do .NET Core
- AutoMapper
- FluentValidator
- Swagger UI com suporte ao JWT

# Arquitetura:
Domain Driven Design
