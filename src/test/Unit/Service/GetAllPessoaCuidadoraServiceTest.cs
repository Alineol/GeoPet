using projetoFinal.Controllers.inputs;
using projetoFinal.Services;
using static src.Unit.helpers.GeneratePessoaCuidadoraHelpers;
namespace src.Unit.Service
{
    public class GetAllPessoaCuidadoraServiceTest
    {
        private readonly PessoaCuidadoraService _service = GeneratePessoaCuidadoraService();

        [Fact]
        public async void ShoulGetAllWithSucess()
        {
            List<PessoaCuidadoraInput> list = new List<PessoaCuidadoraInput>()
            {
                new PessoaCuidadoraInput()
                {
                    Email = "string@gmail1.com",
                    Nome = "stringstring",
                    CEP = "20020000",
                    Senha = "12345678"
                },
                new PessoaCuidadoraInput()
                {
                    Email = "string@gmail2.com",
                    Nome = "stringstring",
                    CEP = "20020000",
                    Senha = "12345678"
                }
            };

            await _service.CreatePessoaCuidadora(list[0]);
            await _service.CreatePessoaCuidadora(list[1]);


            var output = _service.GetAll()?.ToList();
            Assert.Equal(2, output?.Count);
        }
    }
}
