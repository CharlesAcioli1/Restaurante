using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Restaurante.Services.Interfaces;
using Restaurante.Domain;
using Restaurante.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestauranteDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICardapioRepository, CardapioRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemCardapioRepository, ItemCardapioRepository>();
builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();
builder.Services.AddScoped<IGarcomRepository, GarcomRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddScoped<IRestauranteRepository, RestauranteRepository>();
builder.Services.AddScoped<IFilaPedidoRepository, FilaPedidoRepository>();
builder.Services.AddScoped<IMesaGarcomRepository, GarcomMesaRepository>();
builder.Services.AddScoped<IGarcomRestauranteRepository, GarcomRestauranteRepository>();

builder.Services.AddScoped<ICardapioService, CardapioService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemCardapioService, ItemCardapioService>();
builder.Services.AddScoped<IItemPedidoService, ItemPedidoService>();
builder.Services.AddScoped<IGarcomService, GarcomService>();
builder.Services.AddScoped<IMesaService, MesaService>();
builder.Services.AddScoped<IRestauranteService, RestauranteService>();
//builder.Services.AddScoped<IGarcomRestauranteService, GarcomRestaurante>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();