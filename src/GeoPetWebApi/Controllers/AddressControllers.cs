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

        ///<summary>Retorna um endereço</summary>
        ///<response code="200"> retorna um endereço</response>
        ///<response code="400"> retorna um objeto com uma mensagem de erro</response>
    [HttpPost(Name = "getAddress")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultRowstOuput) )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultRowstOuput))]
    public async Task<IActionResult> GetAddress([FromBody]AddressInput input)
    {
        var result = await _service.GetAddressByLat(input);
        if(result.error == null)
        return StatusCode(200, result.display_name);
        return StatusCode(400, result.error);

    }
    }
}
