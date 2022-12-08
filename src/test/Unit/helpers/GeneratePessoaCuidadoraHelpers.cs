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

namespace src.Unit.helpers
{
    public static class GeneratePessoaCuidadoraHelpers
    {
        public static PessoaCuidadoraService GeneratePessoaCuidadoraService()
        {
            return new PessoaCuidadoraService(
            new PessoaCuidadoraRepository(new GeoPetWebApiContextTest()),
            new HttpClient(), InitConfiguration());
        }

        public static PessoaCuidadoraRepository GeneratePessoaCuidadoraRepository()
        {
            return new PessoaCuidadoraRepository(new GeoPetWebApiContextTest());
        }

        public static PessoaCuidadoraController GeneratePessoaCuidadoraController()
        {
            return new PessoaCuidadoraController(
                It.IsAny<ILogger<PessoaCuidadoraController>>(),
                new PessoaCuidadoraService(
                new PessoaCuidadoraRepository(
                new GeoPetWebApiContextTest()),
                new HttpClient(), InitConfiguration()));
        }

    }
}
