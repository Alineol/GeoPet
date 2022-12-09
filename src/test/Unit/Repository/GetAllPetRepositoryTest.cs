using FluentAssertions;
using AutoFixture;
using projetoFinal.db.Repository;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;

namespace src.Unit.Repository;
public class GetAllPetRepositoryTest
{
    static readonly Fixture fixture = new();
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetRepository _repository = GeneratePetRepository(context); 

    [Fact]
    public void ShoulGetAllPetWithSucess()
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

        var output =  _repository.GetAll()?.ToList();

        output?.Count.Should().Be(3);
    }
}

