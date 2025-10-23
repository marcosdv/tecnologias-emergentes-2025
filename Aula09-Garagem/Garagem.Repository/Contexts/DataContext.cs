using Garagem.Application.Entities;
using Garagem.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Garagem.Repository.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opt) : base(opt)
    {
    }

    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ModeloMap());
        modelBuilder.ApplyConfiguration(new VeiculoMap());
    }
}