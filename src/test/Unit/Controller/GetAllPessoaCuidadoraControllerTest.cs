using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using projetoFinal.Controllers;
using projetoFinal.Controllers.inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static src.Unit.helpers.GeneratePessoaCuidadoraHelpers;


namespace src.Unit.Controller
{
    public class GetAllPessoaCuidadoraControllerTest
    {
        private readonly PessoaCuidadoraController _controller = GeneratePessoaCuidadoraController();

        [Fact]
        public async void ShouldGetAllWithSucess()
        {
            List<PessoaCuidadoraInput> list = new List<PessoaCuidadoraInput>()
            {
                new PessoaCuidadoraInput()
                {
                    Email = "string@gmail1.com",
                    Nome = "stringstring",
                    CEP = "20020000",
                    Senha = "12345678"
                },
                new PessoaCuidadoraInput()
                {
                    Email = "string@gmail2.com",
                    Nome = "stringstring",
                    CEP = "20020000",
                    Senha = "12345678"
                }
            };

            await _controller.CreatePessoaCuidadora(list[0]);
            await _controller.CreatePessoaCuidadora(list[1]);

            var output = _controller.GetAll() as ObjectResult;
            var value = output?.Value as List<PessoaCuidadoraInput>;

            output?.StatusCode.Should().Be(200);
            value?.Count.Should().Be(2);
        }
    }
}
