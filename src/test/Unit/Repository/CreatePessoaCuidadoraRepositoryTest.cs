using FluentAssertions;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db.Repository;
using static src.Unit.helpers.GeneratePessoaCuidadoraHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src.Unit.Repository
{
    public class CreatePessoaCuidadoraRepositoryTest
    {
        private readonly PessoaCuidadoraRepository _repository = GeneratePessoaCuidadoraRepository();

        [Fact]
        public void ShouldCreatePessoaCuidadoraWithSucecc()
        {
            PessoaCuidadoraModel input = new PessoaCuidadoraModel()
            {
                CEP = "12345678",
                Nome = "string",
                Senha = "string",
                Email = "string",
                Status = true
            };
            var ouput = _repository.CreatePessoaCuidadora(input);
            ouput.Should().Be(1);
        }
    }
}
