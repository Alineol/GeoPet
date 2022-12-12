using projetoFinal.Services;
using projetoFinal.Controllers.inputs;
using FluentAssertions;
using static src.Unit.helpers.GeneratePessoaCuidadoraHelpers;
namespace src.Unit.Service;

public class CreatePessoaCuidadoraServiceTest: Configuration
{
    private readonly PessoaCuidadoraService _service = GeneratePessoaCuidadoraService();

    [Fact]
    public void CreatePessoaCuidadoraTestShouldSucess()
    {

        PessoaCuidadoraInput pessoaCuidadorainput = new()
        {
            Email = "string@gmail1.com",
            Nome = "stringstring",
            CEP = "20020000",
            Senha = "12345678"

        };

        var output = _service.CreatePessoaCuidadora(pessoaCuidadorainput);

        output.Result.RowsAffected.Should().Be(1);
        output.Result.ErrorMessage.Should().BeNullOrEmpty();


    }

    [Fact]
    public  async void CreatePessoaCuidadoraTestShouldfFailByEmail()
    {

        PessoaCuidadoraInput pessoaCuidadorainput = new()
        {
            Email = "string@gmail2.com",
            Nome = "stringstring",
            CEP = "20020000",
            Senha = "12345678"

        };

        await _service.CreatePessoaCuidadora(pessoaCuidadorainput);

        var output = _service.CreatePessoaCuidadora(pessoaCuidadorainput);

        output.Result.RowsAffected.Should().Be(0);
        output.Result.ErrorMessage.Should().Be("Email Já cadastrado");


    }

    [Fact]
    public void CreatePessoaCuidadoraTestShouldfFailByCep()
    {

        PessoaCuidadoraInput pessoaCuidadorainput = new()
        {
            Email = "string2@gmail.com",
            Nome = "stringstring",
            CEP = "12345678",
            Senha = "12345678"

        };
       
        var output = _service.CreatePessoaCuidadora(pessoaCuidadorainput);

        output.Result.RowsAffected.Should().Be(0);
        output.Result.ErrorMessage.Should().Be("CEP inválido");
    }
}