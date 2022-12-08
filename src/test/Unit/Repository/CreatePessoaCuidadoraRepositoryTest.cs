using FluentAssertions;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Unit.Repository
{
    public class CreatePessoaCuidadoraRepositoryTest
    {
        [Fact]
        public void ShouldCreatePessoaCuidadoraWithSucecc()
        {
            var context = new GeoPetWebApiContextTest();
            var repository = new PessoaCuidadoraRepository(context);
            PessoaCuidadoraModel input = new PessoaCuidadoraModel()
            {
                CEP = "12345678",
                Nome = "string",
                Senha = "string",
                Email = "string",
                Status = true
            };
            var ouput = repository.CreatePessoaCuidadora(input);
            ouput.Should().Be(1);
        }
    }
}
