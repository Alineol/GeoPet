using FluentAssertions;
using AutoFixture;
using projetoFinal.db.Repository;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;

namespace src.Unit.Repository;
public class GetByIdPetRepositoryTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetRepository _repository = GeneratePetRepository(context); 
    private static readonly int ID_ERROR = 9999;
    private static readonly int ID = 1; 
    [Fact]
    public void ShoulGetByIdPetWithSucess()
    {
        List<PessoaCuidadoraModel> cuidadores = new()
            {
                new PessoaCuidadoraModel()
                {
                    CEP = "12345678",
                    Nome = "string1",
                    Senha = "string1",
                    Email = "string",
                    Status = true
                },
                new PessoaCuidadoraModel()
                {
                    CEP = "12345678",
                    Nome = "string2",
                    Senha = "string2",
                    Email = "string",
                    Status = true
                },
                new PessoaCuidadoraModel()
                {
                    CEP = "12345678",
                    Nome = "string3",
                    Senha = "string3",
                    Email = "string",
                    Status = true
                }
            };

        List<PetModel> pets = new()
        {
            new PetModel()
            {
                Status = true,
                PessoaCuidadora = cuidadores[0],
                Nome = "Anita",
                Peso = 10,
                HashLocalizacao = "gbavfekçsf\rhzfnjklcdçsk",
                Idade = 10,
                Raca = "any",
                Porte = "medio",
            },
            new PetModel()
            {
                Status = true,
                PessoaCuidadora = cuidadores[1],
                Nome = "Nala",
                Peso = 5,
                HashLocalizacao = "gbavfekçsf\rhzfnjklcdçsk",
                Idade = 17,
                Raca = "any",
                Porte = "pequeno",
            },
            new PetModel()
            {
                Status = false,
                PessoaCuidadora = cuidadores[2],
                Nome = "Leão",
                Peso = 12,
                HashLocalizacao = "gbavfekçsf\rhzfnjklcdçsk",
                Idade = 10,
                Raca = "any",
                Porte = "pequeno",
            },
        };
        
        pets.ForEach(pet => _repository.CreatePet(pet));

        var output =  _repository.GetById(ID);

        output.Should().NotBeNull();
        output.Nome.Should().Be(pets[0].Nome);
        output.Peso.Should().Be(pets[0].Peso);
        output.Raca.Should().Be(pets[0].Raca);
    }
}

