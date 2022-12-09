using AutoFixture;
using FluentAssertions;
using projetoFinal.db.Repository;
using projetoFinal.Services;
using projetoFinal.Controllers;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.Controllers.inputs;

namespace src.Unit.Services;

public class GetAllPetServiceTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetService _service = GeneratePetService(context);
    private readonly PessoaCuidadoraService _servicePessoa = GeneratePessoaCuidadoraService(context); 
    static readonly Fixture fixture = new();

    [Fact]
    public async void ShouldGetAllWithSucess()
    {
        var cuidadores = fixture.Create<List<PessoaCuidadoraInput>>();
        cuidadores[0].CEP = "20020000";
        cuidadores[1].CEP = "20020000";
        cuidadores[2].CEP = "20020000";

        var pets = fixture.Create<List<PetInput>>();
        pets[0].PessoaCuidadora = cuidadores[0].Email;
        pets[1].PessoaCuidadora = cuidadores[1].Email;
        pets[2].PessoaCuidadora = cuidadores[2].Email;

        await _servicePessoa.CreatePessoaCuidadora(cuidadores[0]);
        await _servicePessoa.CreatePessoaCuidadora(cuidadores[1]);
        await _servicePessoa.CreatePessoaCuidadora(cuidadores[2]);

        _service.CreatePet(pets[0]);
        _service.CreatePet(pets[1]);
        _service.CreatePet(pets[2]);

        var result = _service.GetAll()?.ToList();
        result.Should().NotBeNull();
        result?.Count.Should().Be(3);
    }
}