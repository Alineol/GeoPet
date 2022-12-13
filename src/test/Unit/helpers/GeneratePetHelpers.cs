using Microsoft.Extensions.Logging;
using Moq;
using projetoFinal.Controllers;
using projetoFinal.db.Repository;
using projetoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static src.Configuration;
using AutoFixture;
using projetoFinal.db.Models.Pets;
using projetoFinal.db.Models.PessoaCuidadora;

namespace src.Unit.helpers
{
    public static class GeneratePetHelpers
    {
        public static PetService GeneratePetService(GeoPetWebApiContextTest context)
        {
            return new PetService(
            new PetRepository(context),
            new PessoaCuidadoraRepository(context),
            new HttpClient(), InitConfiguration());
        }

        public static PessoaCuidadoraService GeneratePessoaCuidadoraService(GeoPetWebApiContextTest context)
        {
            return new PessoaCuidadoraService(
            new PessoaCuidadoraRepository(context),
            new HttpClient(), InitConfiguration());
        }

        public static PetRepository GeneratePetRepository(GeoPetWebApiContextTest context)
        {
            return new PetRepository(context);
        }

        public static PetController GeneratePetController(GeoPetWebApiContextTest context)
        {
            return new PetController(
                It.IsAny<ILogger<PetController>>(),
                GeneratePetService(context));
        }

        public static PessoaCuidadoraController GeneratePessoaCuidadoraController(GeoPetWebApiContextTest context)
        {
            return new PessoaCuidadoraController(
                It.IsAny<ILogger<PessoaCuidadoraController>>(),
                GeneratePessoaCuidadoraService(context));
        }

    }
}
