# Ambev Developer Evaluation

## Visão Geral

Este projeto é uma API para avaliação de desenvolvedores da Ambev. Ele inclui funcionalidades para gerenciar vendas, itens de vendas e usuários, seguindo os princípios SOLID e utilizando tecnologias como .NET 8, C# 12, MediatR, AutoMapper e FluentValidation.

## Tecnologias Utilizadas

- .NET 8
- C# 12
- MediatR
- AutoMapper
- FluentValidation
- Entity Framework Core
- Microsoft.Extensions.Logging

## Estrutura do Projeto

- **Ambev.DeveloperEvaluation.WebApi**: Contém os controladores e a configuração da API.
- **Ambev.DeveloperEvaluation.Application**: Contém os handlers de comandos e consultas, além das validações.
- **Ambev.DeveloperEvaluation.Domain**: Contém as entidades de domínio e interfaces de repositório.
- **Ambev.DeveloperEvaluation.ORM**: Contém a implementação dos repositórios e a configuração do Entity Framework Core.
- **Ambev.DeveloperEvaluation.IoC**: Contém a configuração de injeção de dependência.

## Instalação

1. Clone o repositório:
   git clone https://github.com/herbertbarbosajr/Ambev.DeveloperEvaluation_Challenge


2. Navegue até o diretório do projeto:
   cd Ambev.DeveloperEvaluation_Challenge

3. Restaure as dependências do projeto:
   dotnet restore

4. Configure a string de conexão no arquivo `appsettings.json`:
{ "ConnectionStrings": { "DefaultConnection": "Server=host.docker.internal;Database=DeveloperEvaluation;User Id=sa;Password=1234;TrustServerCertificate=True" }, "Jwt": { "SecretKey": "YourSuperSecretKeyForJwtTokenGenerationThatShouldBeAtLeast32BytesLong" }, "Logging": { "LogLevel": { "Default": "Information", "Microsoft": "Warning", "Microsoft.Hosting.Lifetime": "Information" } }, "AllowedHosts": "*" }

5. Execute as migrações do Entity Framework Core para criar o banco de dados:
   dotnet ef database update

   
6. Execute o projeto:
   dotnet run


## Uso

### Endpoints

- **SalesItems**
  - `POST /api/salesitems`: Cria um novo item de venda.
  - `GET /api/salesitems/{id}`: Recupera um item de venda pelo ID.
  - `GET /api/salesitems`: Recupera todos os itens de venda com paginação.
  - `DELETE /api/salesitems/{id}`: Deleta um item de venda pelo ID.

- **Users**
  - `POST /api/users`: Cria um novo usuário.
  - `GET /api/users/{id}`: Recupera um usuário pelo ID.
  - `DELETE /api/users/{id}`: Deleta um usuário pelo ID.

## Contribuição

1. Faça um fork do repositório.
2. Crie uma nova branch:
   git checkout -b minha-nova-feature

3. Faça suas alterações e commit:
   git commit -m "Adiciona nova feature"

4. Envie para o repositório remoto:
   git push origin minha-nova-feature 

5. Abra um Pull Request.


