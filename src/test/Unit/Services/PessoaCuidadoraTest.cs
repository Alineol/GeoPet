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

        PessoaCuidadoraInput pessoaCuidadorainput = new()
        {
            Email = "string@gmail.com",
            Nome = "stringstring",
            CEP = "20020000",
            Senha = "12345678"

        };

        var output = service.CreatePessoaCuidadora(pessoaCuidadorainput);

        output.Result.RowsAffected.Should().Be(1);
        output.Result.ErrorMessage.Should().BeNullOrEmpty();


    }

    [Fact]
    public  async void CreatePessoaCuidadoraTestShouldfFailByEmail()
    {
        var context = new GeoPetWebApiContextTest();
        var repository = new PessoaCuidadoraRepository(context);
        var client = new HttpClient();
        var service = new PessoaCuidadoraService(repository, client, InitConfiguration());

        PessoaCuidadoraInput pessoaCuidadorainput = new()
        {
            Email = "string@gmail.com",
            Nome = "stringstring",
            CEP = "20020000",
            Senha = "12345678"

        };
       
        await service.CreatePessoaCuidadora(pessoaCuidadorainput);
        var output = service.CreatePessoaCuidadora(pessoaCuidadorainput);

        output.Result.RowsAffected.Should().Be(0);
        output.Result.ErrorMessage.Should().Be("Email Já cadastrado");


    }

    [Fact]
    public void CreatePessoaCuidadoraTestShouldfFailByCep()
    {
        var context = new GeoPetWebApiContextTest();
        var repository = new PessoaCuidadoraRepository(context);
        var client = new HttpClient();
        var service = new PessoaCuidadoraService(repository, client, InitConfiguration());

        PessoaCuidadoraInput pessoaCuidadorainput = new()
        {
            Email = "string@gmail.com",
            Nome = "stringstring",
            CEP = "12345678",
            Senha = "12345678"

        };
       
        var output = service.CreatePessoaCuidadora(pessoaCuidadorainput);

        output.Result.RowsAffected.Should().Be(0);
        output.Result.ErrorMessage.Should().Be("CEP inválido");
    }
}