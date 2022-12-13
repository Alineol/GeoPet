using GeoPetWebApi.Controllers.inputs;
using Microsoft.AspNetCore.Mvc;
using projetoFinal.Controllers;
using projetoFinal.Services;

namespace GeoPetWebApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase {
        private readonly ILogger<AddressController> _logger;
        private readonly AddressService _service;

        public AddressController(ILogger<AddressController> logger, AddressService service) {
            _logger = logger;
            _service = service;
        }

        ///<summary>Cria Pessoas Cuidadoras</summary>
        ///<response code="20"> retorna um endereço</response>
        ///<response code="400"> retorna um objeto com uma mensagem de erro</response>
    [HttpPost(Name = "getAddress")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultRowstOuput) )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultRowstOuput))]
    public async Task<IActionResult> GetAddress(double lat, double lon)
    {
        var result = await _service.getAddressByLat(lat, lon);

        return StatusCode(200, result);

    }
    }
}
