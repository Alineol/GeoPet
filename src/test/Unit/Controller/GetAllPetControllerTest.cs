using FluentAssertions;
using AutoFixture;
using projetoFinal.Controllers;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.Services;
using projetoFinal.Controllers.inputs;

namespace src.Unit.Controller;
public class GetAllPetControllerTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetController _controller = GeneratePetController(context); 
    static readonly Fixture fixture = new();

    [Fact]
    public async void ShoulGetAllPetWithSucess()
    {
        var cuidadores = fixture.Create<List<PessoaCuidadoraInput>>();
        cuidadores[0].CEP = "20020000";
        cuidadores[1].CEP = "20020000";
        cuidadores[2].CEP = "20020000";

        var pets = fixture.Create<List<PetInput>>();
        pets[0].PessoaCuidadora = cuidadores[0].Email;
        pets[1].PessoaCuidadora = cuidadores[1].Email;
        pets[2].PessoaCuidadora = cuidadores[2].Email;

        _controller.AddPet(pets[0]);
        _controller.AddPet(pets[1]);
        _controller.AddPet(pets[2]);

        var output = _controller.GetAllPet();
        output.Should().Be(200);
    }
}

