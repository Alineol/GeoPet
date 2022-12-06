using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db.Models.Pets;
using GeoPetWebApi.db.Repository;

namespace src;

public class GeoPetWebApiContextTest: DbContext, IGeoPetContext
{
    public DbSet<PessoaCuidadoraModel> PessoasCuidadoras { get; set; }
    public DbSet<PetModel> Pets { get; set; }

    public GeoPetWebApiContextTest() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serviceProvider = new ServiceCollection()
           .AddEntityFrameworkInMemoryDatabase()
           .BuildServiceProvider();

        optionsBuilder.UseInMemoryDatabase("GeoPetDB").UseInternalServiceProvider(serviceProvider);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PetModel>().HasOne(p => p.PessoaCuidadora).WithMany(a => a.Pets).HasForeignKey("PESSOA_CUIDADORA").OnDelete(DeleteBehavior.Cascade);
    }
}

