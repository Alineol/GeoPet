using projetoFinal.db.Repository;
using projetoFinal.db.Models.Pets;
using AutoFixture;
using projetoFinal.db;

namespace GeoPetWebApi.Test;

public class PetsServiceTest
{
    private static readonly Fixture fixture = new();

    [Fact]
    public void ShouldCreatePet()
    {
        var context = CreateContext();
        // var pet = fixture.Create<PetModel>();
        PetModel pet = new ()
        {
            Nome = "Vira-lata",
            Peso = 12.6M,
            Raca = "Sem raça",
            Porte = "médio",
        };


    }

    [Fact]
    public void ShouldGetAllPets()
    {

    }

    [Fact]
    public void ShouldGetPetById()
    {

    }

    [Fact]
    public void ShouldUpdatePet()
    {

    }

    [Fact]
    public void ShouldUpdateStatusPet()
    {
        
    }

    public Context CreateContext()
    {
        var context = Helpers.GetContextInstanceForTest();
        var repository = new PetRepository(context);
        return repository;
    }
}