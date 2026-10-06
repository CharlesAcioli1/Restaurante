# 🍽️ Restaurante API

## API REST para gerenciamento de um sistema de restaurante, desenvolvida em C# com .NET, utilizando Entity Framework Core para persistência de dados.

# 🏗️ Arquitetura e Princípios SOLID

* **S - Single Responsibility Principle (Princípio da Responsabilidade Única)**
Os Repositories cuida apenas do acesso ao banco de dados.
As Services trata apenas das regras de negócio do cardápio.
As Controllers apenas recebe a requisição e entrega a resposta HTTP.

* **O - Open/Closed Principle (Princípio do Aberto/Fechado)**
O uso do padrão de resposta (Resultado) e a criação de DTOs permitem que seja adicionado novos campos ou comportamentos nas requisições/respostas sem precisar alterar o contrato das entidades do banco de dados ou quebrar outras camadas.

**Ex:**
```csharp
try
{
    await _context.SaveChangesAsync();
    return Resultado.Success(AtualizarRestaurante);
}
catch (Exception)
{
    return Resultado.Falha("Não foi possível atualizar o restaurante no banco de dados!");
}
```

* **L - Liskov Substitution Principle (Princípio da Substituição de Liskov)**
[Digital Ocean](https://www.digitalocean.com/community/conceptual-articles/s-o-l-i-d-the-first-five-principles-of-object-oriented-design-pt#principio-da-substituicao-de-liskov)
[Entenda o LSP (Liskov Substitution Principle) - Canal Balta.io](https://www.youtube.com/watch?v=kt1AqWcxoA0)
As implementações de repositórios (CardapioRepository) respeita o contrato da interface (ICardapioRepository).

* **I - Interface Segregation Principle (Princípio da Segregação de Interfaces)**
Interfaces específicas para cada contexto, como:
IRestauranteRepository,ICardapioRepository e ICardapioService, em vez de ter um único repositório extenso, ou um serviço único com métodos do sistema inteiro.

**Ex:**
public class CardapioService(ICardapioRepository cardapioRepository) : ICardapioService

* **D - Dependency Inversion Principle (Princípio da Inversão de Dependência)**
A controller não instancia new CardapioService(), ela injeta a abstração ICardapioService.
O CardapioService injeta ICardapioRepository, dependendo apenas da interface e não da classe concreta de banco de dados.
[Canal - Balta.io](https://www.youtube.com/watch?v=qvMWR996T9w)

### Ex:
```csharp
public class CardapioService(ICardapioRepository cardapioRepository) : ICardapioService
{
    private readonly ICardapioRepository _cardapioRepository = cardapioRepository;
}
```

### Criada por: Robert C. Martin. Também conhecido como Uncle Bob.

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

O projeto possui elementos compatíveis com Clean Architecture.

# 📁 Estrutura do projeto
src/

├── Restaurante.Domain/         **Entidades, Enums e Objeto de Valor (Resultado)**

├── Restaurante.Infrastructure/ **DbContext, Migrations e Mapeamentos com EF Core**

├── Restaurante.Services/       **Regras de Negócio, Interfaces e DTOs**

└── Restaurante.Presentation/   **Controllers, Endpoints HTTP e Configurações (appsettings)**

# 🔄 Fluxo principal
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

# 🛠️ Tecnologias

C#

.NET 8

ASP.NET Core Web API

Entity Framework Core

Banco de dados relacional (Postgre)

Git / GitHub

Bruno API Client para testes dos endpoints


# 📋 Requisitos

**Para executar o projeto, é necessário ter instalado:**

.NET SDK, compatível com a versão utilizada pelo projeto.(Neste projeto usei a versão .NET 8)

```dotnet tool install --global dotnet-ef --version 8.0.0```

**Clone o repositório para a sua máquina:**

```git clone -b Developer https://github.com/CharlesAcioli1/Restaurante.git```

Pelo terminal git, vá até a pasta do projeto: cd <NOME_DA_PASTA_DO_PROJETO>

Instale e configure em sua máquina o banco de dados [Postgre](https://www.postgresql.org/download/), escolha o seu sistema operacional, baixe e instale em sua máquina. Ao configurar o banco de dados, lembre a senha criada por você durante a configuração.

Vá até: Restaurante.Presentation, clique em appsettings.json.

Em:
```csharp
"ConnectionStrings": {
  "PostgreSQLConnection": "Host=localhost;Port=5432;Database=restaurante_db;Username=Informe o usuário do banco definido por você;Password=Senha criada por você"
}
```

Verifique em Program.cs, se o Postgre está informado na configuração:
```csharp
builder.Services.AddDbContext<RestauranteDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"))); <- Caso não esteja como esse exemplo, fazer a devida modificação.
```

**Restaure as dependências e compile:**

```dotnet restore```

```dotnet build```

**Faça a migration**

```dotnet ef database update --project src/Restaurante.Infrastructure --startup-project src/Restaurante.Presentation```

**Execute a aplicação:**
```dotnet run --project src/Restaurante.Presentation```


# 🗄️ Configuração do banco de dados

A aplicação utiliza o RestauranteDbContext, localizado no projeto:

```src/Restaurante.Infrastructure/```


Antes de executar a aplicação, é necessário verificar a connection string e as configurações do banco utilizadas pelo projeto.

A configuração deve estar de acordo com o ambiente local de execução.

# 🔄 Migrations

As migrations ficam localizadas em:

```src/Restaurante.Infrastructure/Migrations/```

**Listar Migrations**

Para verificar as migrations existentes:

```dotnet ef migrations list \  --project src/Restaurante.Infrastructure \  --startup-project src/Restaurante.Presentation```

**Criar uma migration**

Após alterações no modelo do Entity Framework:

```dotnet ef migrations add NomeDaMigration \  --project src/Restaurante.Infrastructure \  --startup-project src/Restaurante.Presentation```

**Aplicar migrations ao banco**
```dotnet ef database update \  --project src/Restaurante.Infrastructure \  --startup-project src/Restaurante.Presentation```


**Importante:** uma nova migration deve ser criada quando houver alteração no modelo do Entity Framework, como entidades, relacionamentos ou configurações de persistência.

Alterações somente em Controllers, Services, DTOs ou Repositories não exigem uma nova migration.

## ▶️ Executando o projeto

**Na pasta raiz da solução, restaure as dependências:**

```dotnet restore```

**Compile o projeto:**

```dotnet build```

**Execute a API:**

```dotnet run --project src/Restaurante.Presentation```

A URL utilizada pela API será apresentada no terminal após a inicialização da aplicação.
Nela você irá obter a url + port.**(https://localhost:0000)**


## 🌐 Endpoints

A aplicação possui Controllers para diferentes recursos do sistema:

Informe a URL com porta/api/Restaurante

Informe a URL com porta/api/Cardapio

Informe a URL com porta/api/Mesa

Informe a URL com porta/api/Pedido

Informe a URL com porta/api/Item

Informe a URL com porta/api/Garcom

Informe a URL com porta/api/Cozinha

**Ex: https://localhost:0000 <- Informe o número da porta**

Os endpoints podem ser testados utilizando Bruno, Postman ou outro cliente HTTP.

**Exemplo — listar cardápios**
GET Informe a URL com porta/api/Cardapio
**Retorna os cardápios cadastrados.**

**Exemplo — buscar cardápios por restaurante**
GET /api/Cardapio/12/Restaurantes
Retorna os cardápios relacionados ao restaurante de ID 12, conforme a rota implementada no Controller.


# 📚 Referências

[Documentação do ASP.NET Core](https://learn.microsoft.com/aspnet/core/)

[Entity Framework Core — Microsoft](https://learn.microsoft.com/pt-br/ef/core/)

[EF Core Migrations — Microsoft](https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

[Dependency Injection no .NET — Microsoft](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection/overview)

[ASP.NET Core Web API — Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/web-api/?view=aspnetcore-10.0)



📝 ##Observações

- As informações deste README refletem a estrutura e os recursos apresentados no projeto.
- Recursos não identificados no código não são considerados parte da implementação atual.
- Algumas instruções, implementações e regras de negócios, foram pensando em situações futuras.
- 
**Ex:** Regra para CNPJ, sobre o formato ser no formato a seguir: 00.000.000/0000-00, não será possível, pois não aceitará ".","/" e "-".
  Apesar da implementação da regra, o banco de dados foi projetado para aceitar apenas 14 caracteres.

❌ #Problemática:
###Banco de dados:
com uso de OnRestrict, tive que buscar outras soluções para não deletar essa parte, pois usei para que as classes durante toda a construção, ficasse dependente umas das outras, pensando em erros humanos durante o uso de um sistema, ou seja, caso alguém tentasse excluir de alguma forma o restaurante, pós cardápios criado, já não será mais possível. Ao buscar soluções para instanciar algumas classes, como item, só é possível se cozinha for criada primeiramente, não sendo possível a criação de itens, sem cozinha. O sistema em si foi pensado nas falhas humanas ou em tentativa de testes intencionais ou esporádica.

##🔒Motivo do uso OnRestrict no banco de dados:
Usuário do sistema, querer fazer testes de usabilidade.
Possíveis hackers. Caso venha tentar deletar o restaurante de forma maliciosa, não será possível, pois, terá de ser excluído tudo o que estará ligado a ele. Caso algum item exista, não será possível. Foi pensado na segurança do sistema.
