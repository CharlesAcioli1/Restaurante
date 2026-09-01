using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Infrastructure.Configurations;

namespace Restaurante.Infrastructure.Persistencia;

public class RestauranteDbContext : DbContext
{
    public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options)
    {

    }

    // Mapeia a tabela no banco de dados e também constrói
    public DbSet<Domain.Restaurante> Restaurantes { get; set; }
    public DbSet<Domain.Cardapio> Cardapios { get; set; }
    public DbSet<Domain.Cozinha> Cozinhas { get; set; }
    public DbSet<Domain.FilaPedido> FilaPedidos { get; set; }
    public DbSet<Domain.Garcom> Garcons { get; set; }
    public DbSet<Domain.GarcomMesa> GarcomMesas { get; set; }
    public DbSet<Domain.GarcomRestaurante> GarcomRestaurantes { get; set; }
    public DbSet<Domain.Item> Items { get; set; }
    public DbSet<Domain.ItemCardapio> ItemCardapios { get; set; }
    public DbSet<Domain.ItemPedido> ItemPedidos { get; set; }
    public DbSet<Domain.Mesa> Mesas { get; set; }
    public DbSet<Domain.Pedido> Pedidos { get; set; }
    public DbSet<Domain.StatusCozinha> StatusCozinhas { get; set; }
    public DbSet<Domain.StatusGarcom> StatusGarcons { get; set; }
    public DbSet<Domain.StatusItemPedido> StatusItemPedidos { get; set; }
    public DbSet<Domain.StatusMesa> StatusMesas { get; set; }
    public DbSet<Domain.StatusPedido> StatusPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
                //└── Sobrescreve o comportamento padrão da classe DbContext
    {
        base.OnModelCreating(modelBuilder);

        // Aplica automaticamente todas as configurações que implementam IEntityTypeConfiguration neste assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestauranteDbContext).Assembly);
        // │          │                               │                            └── 3º PASSO: Varre o projeto e localiza todas as suas 17 classes de Configuration
        // │          │                               │
        // │          │                               └── 2º PASSO: Aponta para a DLL da camada Infrastructure
        // │          │
        // │          └── 1º MÉTODO: Registra de uma só vez todas as tabelas e relacionamentos no SQL Server!
        // │
        // └── O Construtor do Modelo
    }
}