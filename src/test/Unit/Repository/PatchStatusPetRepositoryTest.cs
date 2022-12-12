using FluentAssertions;
using AutoFixture;
using projetoFinal.db.Repository;
using static src.Unit.helpers.GeneratePetHelpers;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.Controllers.inputs;

namespace src.Unit.Repository;
public class PatchStatusPetRepositoryTest
{
    private readonly static GeoPetWebApiContextTest context = new();
    private readonly PetRepository _repository = GeneratePetRepository(context); 
    private static readonly int ID = 1; 
    [Fact]
    public void ShoulUpdateStatusPetWithSucess()
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
        
        _repository.CreatePet(pet);

        var status = _repository.GetById(ID);
        status.Status.Should().BeTrue();

        _repository.UpdateStatus(ID);

        status = _repository.GetById(ID);
        //status.Status.Should().BeFalse();
    }
}

