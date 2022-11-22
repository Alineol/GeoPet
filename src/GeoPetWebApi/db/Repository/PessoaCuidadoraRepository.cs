using projetoFinal.Controllers.inputs;
using projetoFinal.db.Models.PessoaCuidadora;
using System.Reflection.Metadata.Ecma335;

namespace projetoFinal.db.Repository
{
    public class PessoaCuidadoraRepository
    {
        private readonly Context _context;
        public PessoaCuidadoraRepository(Context context)
        {
            _context = context;
        }

        public int CreatePessoaCuidadora(PessoaCuidadoraModel pessoaCuidadora) {

            _context.PessoasCuidadoras.Add(pessoaCuidadora);
            return _context.SaveChanges();
            
        }

        public PessoaCuidadoraModel? GetByEmail(string email)
        {
            var result =  _context.PessoasCuidadoras.Where(p => p.Email == email).FirstOrDefault();
            return result;
        }

        public IEnumerable<PessoaCuidadoraModel>? GetAll() {

            var result = _context.PessoasCuidadoras.Select(pessoa => new PessoaCuidadoraModel() {
                Email = pessoa.Email,
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                CEP = pessoa.CEP,
                Status = pessoa.Status,
            });
            return result;
        }
        
    }

    
}
