using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using AutoFixture;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db.Repository;
using projetoFinal.Services;
using Microsoft.Extensions.Configuration;
using projetoFinal.Controllers.inputs;
using FluentAssertions;
using projetoFinal.Controllers;

namespace src.Unit.Services;

public class PessoaCuidadoraServiceTest: Configuration
{
    [Fact]
    public void CreatePessoaCuidadoraTestShouldSucess()
    {
        var context = new GeoPetWebApiContextTest();
        var repository = new PessoaCuidadoraRepository(context);
        var client = new HttpClient();
        var service = new PessoaCuidadoraService(repository, client, InitConfiguration());
        var output = new ResultRowstOuput();

        PessoaCuidadoraInput pessoaCuidadorainput = new()
        {
            Email = "string@gmail.com",
            Nome = "stringstring",
            CEP = "20020000",
            Senha = "12345678"

        };

        var result = service.CreatePessoaCuidadora(pessoaCuidadorainput);

        result.Result.Should().NotBeNull();


    }
}