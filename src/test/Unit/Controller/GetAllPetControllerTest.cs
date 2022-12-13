using FluentAssertions;
using AutoFixture;
using projetoFinal.db.Repository;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.Controllers;
using projetoFinal.Controllers.inputs;

namespace src.Unit.Controller;
public class GetAllPetControllerTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetController _controller = GeneratePetController(context);
    private readonly PessoaCuidadoraController _pessoaController = GeneratePessoaCuidadoraController(context);
    static readonly Fixture fixture = new();
    [Fact]
    public async void ShoulGetAllPetWithSucess()
    {
        PessoaCuidadoraInput cuidador = new()
            {
                Email = "string@gmail.com",
                Nome = "stringstring",
                CEP = "20020000",
                Senha = "12345678"

            };

        
        PetInput pet = new ()
            {
                PessoaCuidadora = "string@gmail.com",
                Nome = "Anita",
                Peso = 10,
                HashLocalizacao = "gbavfekçsf\rhzfnjklcdçsk",
                Idade = 10,
                Raca = "any",
                Porte = "medio",
            };

        await _pessoaController.CreatePessoaCuidadora(cuidador);
        
        _controller.AddPet(pet);

        var result = _controller.GetAllPet();

        result.Should().Be(200);
    }
}

