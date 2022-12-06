using Microsoft.EntityFrameworkCore;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;

namespace GeoPetWebApi.Test;

public class GeoPetTestContext : DbContext
{

    public GeoPetTestContext(DbContextOptions<GeoPetTestContext> options) : base(options) {}

    public virtual DbSet<PetModel> Pets { get; set; } = default!;
    public virtual DbSet<PessoaCuidadoraModel> PessoasCuidadoras { get; set; } = default!;
    
}