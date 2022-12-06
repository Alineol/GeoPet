using Microsoft.EntityFrameworkCore;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.db;
using AutoFixture;

namespace GeoPetWebApi.Test;

public static class Helpers
{
    private static readonly Fixture fixture = new();

    public static Context GetContextInstanceForTest()
    {
        var contextOptions = new DbContextOptionsBuilder<Context>()
          .UseInMemoryDatabase(inMemoryDbName)
          .Options;
        var context = new Context(contextOptions);
        context.Pets.AddRange(GetPets());
        context.PessoasCuidadoras.AddRange(GetPessoaCuidadoras());
        context.SaveChanges();
        return context;

    }
    public static IEnumerable<PetModel> GetPets()
    {
        var pets = fixture.Create<IEnumerable<PetModel>>();
        return pets;
    }

    public static IEnumerable<PessoaCuidadoraModel> GetPessoaCuidadoras()
    {
        var pessoas = fixture.Create<IEnumerable<PessoaCuidadoraModel>>();
        return pessoas;
    }
}