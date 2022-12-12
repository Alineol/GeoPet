using FluentAssertions;
using AutoFixture;
using projetoFinal.db.Repository;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;

namespace src.Unit.Repository;
public class CreatePetRepositoryTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetRepository _repository = GeneratePetRepository(context); 

    [Fact]
    public void ShoulGetAllPetWithSucess()
    {
        PessoaCuidadoraModel cuidador = new()
                {
                    CEP = "12345678",
                    Nome = "string1",
                    Senha = "string1",
                    Email = "string",
                    Status = true
                };

        PetModel pet = new ()
            {
                Status = true,
                PessoaCuidadora = cuidador,
                Nome = "Anita",
                Peso = 10,
                HashLocalizacao = "gbavfekçsf\rhzfnjklcdçsk",
                Idade = 10,
                Raca = "any",
                Porte = "medio",
            };
        
        var result = _repository.CreatePet(pet);

        var output =  _repository.GetAll()?.ToList();

        output?.Count.Should().Be(1);
        output[0].Nome.Should().Be(pet.Nome);
        output[0].Peso.Should().Be(pet.Peso);
        output[0].Porte.Should().Be(pet.Porte);
    }
}

