﻿using projetoFinal.Controllers.inputs;
using projetoFinal.db.Models.PessoaCuidadora;
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

        public PessoaCuidadoraModel? GetByCPF(string CPF)
        {
            var result =  _context.PessoasCuidadoras.Where(p => p.CPF == CPF).FirstOrDefault();
            return result;
        }
    }

    
}
