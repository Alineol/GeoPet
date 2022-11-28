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

        public IEnumerable<PetModel> GetAll() {
            var result = _context.Pets.Select(pet => new PetModel()
            {
                Nome = pet.Nome,
                Peso = pet.Peso,
                Idade = pet.Idade,
                Raca = pet.Raca,
                Porte = pet.Porte,
                Status = pet.Status,
                Id = pet.Id,
                PessoaCuidadora = pet.PessoaCuidadora,
                HashLocalizacao = pet.HashLocalizacao,
            });

            return result;
        }

        public PetModel? GetById(int id)
        {
            var result = _context.Pets.Where(p => p.Id == id).FirstOrDefault();
            
            return result;
        }

        public int Update(int id, PetInput dados) {
            var pet = _context.Pets.Where(p => p.Id == id).FirstOrDefault();

            if (pet == null) return 0;

            pet.Nome = dados.Nome;
            pet.Peso = dados.Peso;
            pet.Idade = dados.Idade;
            pet.Raca = dados.Raca;
            pet.Porte = dados.Porte;
            pet.HashLocalizacao = dados.HashLocalizacao;
            // pet.PessoaCuidadora = dados.PessoaCuidadora;

            return _context.SaveChanges();
        }

        public int UpdateStatus(int id) {
            var pet = GetById(id);

            if (pet == null) return 0;
            
            pet.Status = !pet.Status;

            return _context.SaveChanges();
        }
    }

    
}
