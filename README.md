#🍽️ Restaurante API

API REST para gerenciamento de um sistema de restaurante, desenvolvida em C# com .NET, utilizando Entity Framework Core para persistência de dados.

##🏗️ Arquitetura

O projeto utiliza principalmente Arquitetura em Camadas, organizada em:

Domain — entidades e componentes relacionados ao domínio.

Services — regras e fluxo da aplicação, além dos DTOs.

Infrastructure — acesso ao banco de dados, Entity Framework Core e Repositories.

Presentation — Controllers e endpoints HTTP.

Padrões e conceitos utilizados

Repository Pattern

Service Layer

Dependency Injection

DTOs

Interfaces

Entity Framework Core

O projeto possui elementos compatíveis com Clean Architecture, mas não é documentado aqui como uma implementação completa de Clean Architecture.

###📁 Estrutura do projeto
src/
├── Restaurante.Domain/
├── Restaurante.Infrastructure/
├── Restaurante.Presentation/
└── Restaurante.Services/

##🔄 Fluxo principal
Cliente
   ↓
Controller
   ↓
Service
   ↓
Repository
   ↓
Entity Framework Core
   ↓
Banco de dados

🛠️ Tecnologias

C#

.NET

ASP.NET Core Web API

Entity Framework Core

Banco de dados relacional

Git / GitHub

Bruno API Client para testes dos endpoints

##📋 Requisitos

Para executar o projeto, é necessário ter instalado:

.NET SDK, compatível com a versão utilizada pelo projeto.

Um banco de dados configurado para a aplicação.

Entity Framework Core CLI, caso seja necessário executar migrations pelo terminal.

Git, caso o projeto seja obtido através do repositório.

Verificar o .NET
```dotnet --version```

Verificar o Git
```git --version```

Instalar o Entity Framework Core CLI

Caso o comando dotnet ef não esteja disponível:

dotnet tool install --global dotnet-ef

##🗄️ Configuração do banco de dados

A aplicação utiliza o RestauranteDbContext, localizado no projeto:

```src/Restaurante.Infrastructure/```


Antes de executar a aplicação, é necessário verificar a connection string e as configurações do banco utilizadas pelo projeto.

A configuração deve estar de acordo com o ambiente local de execução.

##🔄 Migrations

As migrations ficam localizadas em:

```src/Restaurante.Infrastructure/Migrations/```

###Listar Migrations

Para verificar as migrations existentes:

dotnet ef migrations list \
  --project src/Restaurante.Infrastructure \
  --startup-project src/Restaurante.Presentation

Criar uma migration

Após alterações no modelo do Entity Framework:

dotnet ef migrations add NomeDaMigration \
  --project src/Restaurante.Infrastructure \
  --startup-project src/Restaurante.Presentation

Aplicar migrations ao banco
dotnet ef database update \
  --project src/Restaurante.Infrastructure \
  --startup-project src/Restaurante.Presentation


Importante: uma nova migration deve ser criada quando houver alteração no modelo do Entity Framework, como entidades, relacionamentos ou configurações de persistência.

Alterações somente em Controllers, Services, DTOs ou Repositories não exigem uma nova migration.

##▶️ Executando o projeto

Na raiz da solução, restaure as dependências:

```dotnet restore```


Compile o projeto:

```dotnet build```


Execute a API:

```dotnet run --project src/Restaurante.Presentation```


A URL utilizada pela API será apresentada no terminal após a inicialização da aplicação.

##🌐 Endpoints

A aplicação possui Controllers para diferentes recursos do sistema:

/api/Restaurante

/api/Cardapio

/api/Mesa

/api/Pedido

/api/Item

/api/Garcom

/api/Cozinha

###Os endpoints podem ser testados utilizando Bruno, Postman ou outro cliente HTTP.

Exemplo — listar cardápios
GET /api/Cardapio


###Retorna os cardápios cadastrados.

Exemplo — buscar cardápios por restaurante
GET /api/Cardapio/12/Restaurantes


Retorna os cardápios relacionados ao restaurante de ID 12, conforme a rota implementada no Controller.

##📦 Git

Para obter o projeto:

```git clone https://github.com/CharlesAcioli1/Restaurante.git```


Entre na pasta do projeto:

```cd Restaurante```


Restaure as dependências:

```dotnet restore```


Execute a aplicação:

dotnet run --project src/Restaurante.Presentation

##📚 Referências

[Documentação do ASP.NET Core](https://learn.microsoft.com/aspnet/core/)

[Entity Framework Core — Microsoft](https://learn.microsoft.com/pt-br/ef/core/)

[EF Core Migrations — Microsoft](https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

[Dependency Injection no .NET — Microsoft](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection/overview)

[ASP.NET Core Web API — Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/web-api/?view=aspnetcore-10.0)

##📝 Observações

As informações deste README refletem a estrutura e os recursos apresentados no projeto.

Recursos não identificados no código não são considerados parte da implementação atual.
