using GeoPetWebApi.Controllers.inputs;
using Microsoft.AspNetCore.Mvc;
using projetoFinal.Controllers.inputs;
using projetoFinal.Services;

namespace projetoFinal.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class PetController: ControllerBase {
        private readonly ILogger<PetController> _logger;
        private readonly PetService _service;

        public PetController(ILogger<PetController> logger, PetService service) {
            _logger = logger;
            _service = service;
        }
        ///<summary>Rota para fazer inserção de pet</summary>
        ///<response code="201"> Pet foi inserido corretamente </response>
        ///<response code="400"> Requisição no formato errado </response>
        [HttpPost(Name = "PetInput")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultRowstOuput))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultRowstOuput))]
        public async Task<IActionResult> AddPet([FromBody] PetInput data) {
            var response = await _service.CreatePet(data);
            if (response.ErrorMessage == null) {
                return StatusCode(201, response);
            }
            return StatusCode(400, response);
        }
    }
