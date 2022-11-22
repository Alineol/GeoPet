using Microsoft.AspNetCore.Mvc;
using projetoFinal.Services;
using projetoFinal.db.Models.PessoaCuidadora;
using projetoFinal.Controllers.inputs;
using GeoPetWebApi.Controllers.inputs;

namespace projetoFinal.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoaCuidadoraController : ControllerBase
{
    private readonly ILogger<PessoaCuidadoraController> _logger;
    private readonly PessoaCuidadoraService _service;

    public PessoaCuidadoraController(ILogger<PessoaCuidadoraController> logger, PessoaCuidadoraService service)
    {
        _logger = logger;
        _service = service;
    }
    ///<summary>Cria Pessoas Cuidadoras</summary>
    ///<response code="201"> retorna um objeto com a quantidade de linhas afetadas</response>
    ///<response code="400"> retorna um objeto com uma mensagem de erro</response>
    [HttpPost(Name = "CreatePessoaCuidadora")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultRowstOuput) )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResultRowstOuput))]
    public async Task<IActionResult> CreatePessoaCuidadora(PessoaCuidadoraInput pessoaCuidadora)
    {
        var result = await _service.CreatePessoaCuidadora(pessoaCuidadora);

        if (result.ErrorMessage == null) { return StatusCode(201, result); }
        return StatusCode(400,result);

    }
    ///<summary>Retorna todas as pessoas cuidadoras cadastradas no bd</summary>
    ///<response code="200"> retorna uma lista de pesssoas cuidadoras</response>
    ///<response code="404">retorna um objeto com uma mensagem de erro </response>
    [HttpGet(Name = "GetAll")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultRowstOuput))]
    public IActionResult GetAll() {
        var list = _service.GetAll();
        if (list == null) return StatusCode(404, new ResultRowstOuput() {
            ErrorMessage = "Não há pessoas cadastradas",
        });
        return Ok(list);
    }
    
}
