using Microsoft.EntityFrameworkCore;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db.Models.Pets;

namespace GeoPetWebApi.db.Repository
{

    namespace video_portal.Repository
    {
        public interface IGeoPetContext
        {
            public DbSet<PessoaCuidadoraModel> PessoasCuidadoras { get; set; }
            public DbSet<PetModel> Pets { get; set; }
            public int SaveChanges();
        }
    }

}
