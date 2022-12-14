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
    public class UpdateStatusPessoaCuidadoraRepositoryTest
    {
        private readonly PessoaCuidadoraRepository _repository = GeneratePessoaCuidadoraRepository();

        [Fact]
        public void ShouldUpdateStatusWithSucess()
        {
            PessoaCuidadoraModel input = new PessoaCuidadoraModel()
            {
                CEP = "12345678",
                Nome = "string",
                Senha = "string",
                Email = "string",
                Status = true
            };

            _repository.CreatePessoaCuidadora(input);

            var output = _repository.UpdateStatus(input.Email);
            output.Should().Be(1);
        }
    }
}
