using FluentAssertions;
using AutoFixture;
using projetoFinal.db.Repository;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.Controllers.inputs;

namespace src.Unit.Repository;
public class UpdatePetRepositoryTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetRepository _repository = GeneratePetRepository(context); 
    private static readonly int ID = 1; 
    [Fact]
    public void ShoulUpdatePetWithSucess()
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

        var valuePet = _repository.GetById(ID);
        valuePet!.Peso.Should().Be(pets[0].Peso);

        var upPet = new PetInput()
        {
            Nome = pets[0].Nome,
            Peso = 7,
            PessoaCuidadora = pets[0].PessoaCuidadora.Email,
            HashLocalizacao = pets[0].HashLocalizacao,
            Idade = pets[0].Idade,
            Raca = pets[0].Raca,
            Porte = pets[0].Porte,
        };

        _repository.Update(ID, upPet);

        valuePet = _repository.GetById(ID);
        valuePet!.Peso.Should().Be(upPet.Peso);
    }
}

