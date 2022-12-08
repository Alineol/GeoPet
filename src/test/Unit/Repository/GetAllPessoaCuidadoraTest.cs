using FluentAssertions;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static src.Unit.helpers.GeneratePessoaCuidadoraHelpers;
namespace src.Unit.Repository
{
    public class GetAllPessoaCuidadoraTest
    {
        private readonly PessoaCuidadoraRepository _repository = GeneratePessoaCuidadoraRepository();

        [Fact]
        public  void ShoulGetAllPessoaCuidadoraWithSucess()
        {

            List<PessoaCuidadoraModel> list = new List<PessoaCuidadoraModel>()
            {
                new PessoaCuidadoraModel()
                {
                    CEP = "12345678",
                    Nome = "string1",
                    Senha = "string1",
                    Email = "string",
                    Status = true
                },
                new PessoaCuidadoraModel()
                {
                    CEP = "12345678",
                    Nome = "string2",
                    Senha = "string2",
                    Email = "string",
                    Status = true
                },
                new PessoaCuidadoraModel()
                {
                    CEP = "12345678",
                    Nome = "string3",
                    Senha = "string3",
                    Email = "string",
                    Status = true
                }
            };

             list.ForEach(p => {  _repository.CreatePessoaCuidadora(p); });

            var output =  _repository.GetAll()?.ToList();

            output?.Count.Should().Be(3);
        }
           
            
        
    }
}
