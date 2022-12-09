using AutoFixture;
using FluentAssertions;
using projetoFinal.Services;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.Controllers.inputs;

namespace src.Unit.Services;

public class CreatePetServiceTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetService _service = GeneratePetService(context);
    private readonly PessoaCuidadoraService _servicePessoa = GeneratePessoaCuidadoraService(context); 
    static readonly Fixture fixture = new();

    [Fact]
    public async void ShouldCreatePetWithSucess()
    {
        var cuidador = fixture.Create<PessoaCuidadoraInput>();
        cuidador.CEP = "20020000";

        var pet = fixture.Create<PetInput>();
        pet.PessoaCuidadora = cuidador.Email;

        await _servicePessoa.CreatePessoaCuidadora(cuidador);

        var output = _service.CreatePet(pet);

        output.ErrorMessage.Should().BeNull();
        output.SucessMessage.Should().NotBeNull();
        output.SucessMessage.Should().Contain("Created Pet with id");
    }

    [Fact]
    public void ShouldFailIfPessoaCuidadoraNotFound()
    {
        var pet = fixture.Create<PetInput>();

        var output = _service.CreatePet(pet);

        output.ErrorMessage.Should().NotBeNull();
        output.SucessMessage.Should().BeNull();
        output.ErrorMessage.Should().Contain("Email não corresponde a um usuário válido");
    }
}