using GeoPetWebApi.Controllers.inputs;
using Microsoft.AspNetCore.Mvc;
using projetoFinal.Controllers.inputs;
using projetoFinal.Services;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> AddPet([FromBody] PetInput data) {
            var response = await _service.CreatePet(data);
            if (response.ErrorMessage == null) {
                return StatusCode(201, response);
            }
            return StatusCode(400, response);
        }

        ///<summary>Rota para buscar todos os pets cadastrados</summary>
        ///<response code="200"> Retorna uma lista de pets </response>
        ///<response code="404">retorna um objeto com uma mensagem de erro </response>
        [HttpGet(Name = "GetAllPet")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultRowstOuput))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultRowstOuput))]
        [Authorize]
        public IActionResult GetAllPet() {
            var pets = _service.GetAll();
            if (pets == null) return StatusCode(404, new ResultRowstOuput() {
            ErrorMessage = "N�o h� pets cadastrados",
            });
            return StatusCode(200, pets);
        }

        ///<summary>Rota para buscar um pet pelo id</summary>
        ///<response code="200"> Retorna um pet pelo id </response>
        ///<response code="404">retorna um objeto com uma mensagem de erro </response>
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultRowstOuput))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultRowstOuput))]
        [Authorize]
        public IActionResult GetById(int id) {
            var pet = _service.GetById(id);
            if (pet == null) return StatusCode(404, new ResultRowstOuput() {
            ErrorMessage = "Pet não encontrado",
            });
            return StatusCode(200, pet);
        }

         ///<summary>Atualiza dados da pessoa cuidadora</summary>
    ///<response code="400"> Encontra um problema na atualização</response>
    ///<response code="404"> Usuário não autorizado de realizar a atualização </response>
    ///<response code="204"> Atualiza com sucesso os dados </response>
    [HttpPut(Name = "UpdatePet")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultRowstOuput))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultRowstOuput))]
    [Authorize]
    public IActionResult UpdatePet(int id,  [FromBody]PetInput inputPet)
    {
        if(inputPet == null) return StatusCode(400, new ResultRowstOuput() {
            ErrorMessage = "Dados inválidos",
        });

        var result = _service.UpdatePet(id, inputPet);

        if (result.ErrorMessage == null) 
        { 
            return StatusCode(200, result);
        }
        return StatusCode(400,result);
        
        // eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InN0cmluZyIsInNlbmhhIjoiMTIzNDU2NyIsIm5iZiI6MTY2OTYwMzE0NSwiZXhwIjoxNjY5Nzc1OTQ1LCJpYXQiOjE2Njk2MDMxNDUsImlzcyI6IkdydXBvQWxpbmVPbGl2ZWlyYUVkdWFyZG9Tb3V6YU1hcmNlbGxlTW9udGVpcm8iLCJhdWQiOiJBdmFsaWFkb3Jlc0FjZWxlcmFjYW9DU2hhcnBUcnliZSJ9.lQj02t_KadDwOTKBL8IrQRUnL6iDXGZQiDFNuEesISo
    }

    }
