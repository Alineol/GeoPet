﻿using projetoFinal.Controllers.inputs;
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

        public PessoaCuidadoraModel? login(string password, string email) {
            var result = _context.PessoasCuidadoras.Where(p => p.Email.Equals(email) & p.Senha.Equals(password)).FirstOrDefault();
            return result;
        }

        public bool Update(string email, PessoaCuidadoraInput dados)
        {
            var person = _context.PessoasCuidadoras.Where(p => p.Email == email).FirstOrDefault();

            if (person == null) return false;
            
            person.Email = dados.Email;
            person.Senha = dados.Senha;
            person.CEP = dados.CEP;
            person.Nome = dados.Nome;

            _context.SaveChanges();

            return true;
        }
        
    }

    
}
