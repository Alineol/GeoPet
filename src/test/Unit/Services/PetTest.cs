using AutoFixture;
using FluentAssertions;
using projetoFinal.db.Repository;
using projetoFinal.Services;
using projetoFinal.Controllers;

namespace src.Unit.Services;

public class PetServiceTest : Configuration
{
    Fixture fixture = new();
    static GeoPetWebApiContextTest context = new();
    static PetRepository repositoryPet = new(context);
    static PessoaCuidadoraRepository repositoryPessoa = new(context);
    static HttpClient client = new();
    PetService service = new(repositoryPet, repositoryPessoa, client, InitConfiguration());

    [Fact]
    public void GetAllPetsTestShouldSucess()
    {
        //var output = new ResultRowstOuput();
        var result = service.GetAll();

        result.Should().NotBeNull();
    }

    [Fact]
    public void GetByIdPetTestShouldSucess()
    {
        //var output = new ResultRowstOuput();
        var result = service.GetById(1);

        result.Should().NotBeNull();
    }
}