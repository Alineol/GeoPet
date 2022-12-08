using projetoFinal.db.Repository;
using projetoFinal.Services;
using projetoFinal.Controllers.inputs;
using FluentAssertions;

namespace src.Unit.Services;

public class CreatePessoaCuidadoraServiceTest: Configuration
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
        output.Result.ErrorMessage.Should().Be("Email J� cadastrado");


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
        output.Result.ErrorMessage.Should().Be("CEP inv�lido");
    }
}