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

namespace src.Unit.Controller
{
    public class CreatePessoaCuidadoraControllerTest
    {
        

        [Fact]
        public async void ShouldCreatePessoaCuidadoraWithStatus201()
        {
            var context = new GeoPetWebApiContextTest();
            var repository = new PessoaCuidadoraRepository(context);
            var client = new HttpClient();
            var service = new PessoaCuidadoraService(repository, client, InitConfiguration());
            var controller = new PessoaCuidadoraController(It.IsAny<ILogger<PessoaCuidadoraController>>(), service);

            PessoaCuidadoraInput pessoaCuidadorainput = new()
            {
                Email = "string@gmail.com",
                Nome = "stringstring",
                CEP = "20020000",
                Senha = "12345678"

            };


            var output = controller.CreatePessoaCuidadora(pessoaCuidadorainput).Result as ObjectResult;
            var value = output?.Value as ResultRowstOuput;

            output?.StatusCode.Should().Be(201);
            value?.RowsAffected.Should().Be(1);
            value?.ErrorMessage.Should().BeNullOrEmpty();
        }

        [Fact]
        public async void ShouldCreatePessoaCuidadoraWithFailStatus400()
        {
            var context = new GeoPetWebApiContextTest();
            var repository = new PessoaCuidadoraRepository(context);
            var client = new HttpClient();
            var service = new PessoaCuidadoraService(repository, client, InitConfiguration());
            var controller = new PessoaCuidadoraController(It.IsAny<ILogger<PessoaCuidadoraController>>(), service);

            PessoaCuidadoraInput pessoaCuidadorainput = new()
            {
                Email = "string@gmail.com",
                Nome = "stringstring",
                CEP = "12345678",
                Senha = "12345678"
            };


            var output = controller.CreatePessoaCuidadora(pessoaCuidadorainput).Result as ObjectResult;
            var value = output?.Value as ResultRowstOuput;

            output?.StatusCode.Should().Be(400);
            value?.RowsAffected.Should().Be(0);
            value?.ErrorMessage.Should().NotBeNullOrEmpty();
        }
    }
}
