using Microsoft.EntityFrameworkCore;

namespace Restaurante.Infrastructure.Persistencia;

public class RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Restaurante> Restaurantes { get; set; }
    public DbSet<Domain.Cardapio> Cardapios { get; set; }
    public DbSet<Domain.FilaPedido> FilaPedidos { get; set; }
    public DbSet<Domain.Garcom> Garcons { get; set; }
    public DbSet<Domain.GarcomMesa> GarcomMesas { get; set; }
    public DbSet<Domain.GarcomRestaurante> GarcomRestaurantes { get; set; }
    public DbSet<Domain.Item> Items { get; set; }
    public DbSet<Domain.ItemCardapio> ItemCardapios { get; set; }
    public DbSet<Domain.ItemPedido> ItemPedidos { get; set; }
    public DbSet<Domain.Mesa> Mesas { get; set; }
    public DbSet<Domain.Pedido> Pedidos { get; set; }
    public DbSet<Domain.StatusItemPedido> StatusItemPedidos { get; set; }
    public DbSet<Domain.StatusMesa> StatusMesas { get; set; }
    public DbSet<Domain.StatusPedido> StatusPedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestauranteDbContext).Assembly);
    }
}