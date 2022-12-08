using projetoFinal.Controllers;
using projetoFinal.db.Repository;
using projetoFinal.Services;
using Moq;
using static src.Configuration;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using projetoFinal.Controllers.inputs;
using Moq.AutoMock;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using static src.Unit.helpers.GeneratePessoaCuidadoraHelpers;


namespace src.Unit.Controller
{
    public class CreatePessoaCuidadoraControllerTest
    {
        private readonly PessoaCuidadoraController _controller = GeneratePessoaCuidadoraController();
        

        [Fact]
        public  void ShouldCreatePessoaCuidadoraWithStatus201()
        {

            PessoaCuidadoraInput pessoaCuidadorainput = new()
            {
                Email = "string@gmail.com",
                Nome = "stringstring",
                CEP = "20020000",
                Senha = "12345678"

            };


            var output = _controller.CreatePessoaCuidadora(pessoaCuidadorainput).Result as ObjectResult;
            var value = output?.Value as ResultRowstOuput;

            output?.StatusCode.Should().Be(201);
            value?.RowsAffected.Should().Be(1);
            value?.ErrorMessage.Should().BeNullOrEmpty();
        }

        [Fact]
        public  void ShouldCreatePessoaCuidadoraWithFailStatus400()
        {
            
            PessoaCuidadoraInput pessoaCuidadorainput = new()
            {
                Email = "string@gmail.com",
                Nome = "stringstring",
                CEP = "12345678",
                Senha = "12345678"
            };


            var output = _controller.CreatePessoaCuidadora(pessoaCuidadorainput).Result as ObjectResult;
            var value = output?.Value as ResultRowstOuput;

            output?.StatusCode.Should().Be(400);
            value?.RowsAffected.Should().Be(0);
            value?.ErrorMessage.Should().NotBeNullOrEmpty();
        }
    }
}
