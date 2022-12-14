using projetoFinal.Services;
using static src.Unit.helpers.GeneratePessoaCuidadoraHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using projetoFinal.db.Models.PessoaCuidadora;
using FluentAssertions;

namespace src.Unit.Service
{
    public class UpdateStatusPessoaCuidadoraServiceTest
    {
        private readonly PessoaCuidadoraService _service = GeneratePessoaCuidadoraService();


        [Fact]
        public async void ShouldUpadteWithSucess()
        {
            PessoaCuidadoraModel input = new PessoaCuidadoraModel()
            {
                CEP = "20020000",
                Nome = "string",
                Senha = "string",
                Email = "string",
                Status = true
            };
            
            await _service.CreatePessoaCuidadora(input);

            var output = _service.UpdateStatusPessoaCuidadora(input.Email);

            output.RowsAffected.Should().Be(1);
            output.SucessMessage.Should().Be("Pessoa cuidadora desativada.");

            var output2 = _service.UpdateStatusPessoaCuidadora(input.Email);

            output2.RowsAffected.Should().Be(1);
            output2.SucessMessage.Should().Be("Pessoa cuidadora ativada.");

        }
    }
}
