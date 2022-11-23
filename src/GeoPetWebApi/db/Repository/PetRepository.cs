using projetoFinal.Controllers.inputs;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db.Models.Pets;
using System.Reflection.Metadata.Ecma335;

namespace projetoFinal.db.Repository
{
    public class PetRepository
    {
        private readonly Context _context;
        public PetRepository(Context context)
        {
            _context = context;
        }

        public int CreatePet(PetModel pet) {

            _context.Pets.Add(pet);
            return _context.SaveChanges();
        }
        
    }

    
}
