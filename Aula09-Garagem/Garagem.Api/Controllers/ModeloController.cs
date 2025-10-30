using Garagem.Application.Commands.Modelo;
using Garagem.Application.Entities;
using Garagem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Garagem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModeloController : ControllerBase
{
    private readonly IModeloService _service;

    public ModeloController(IModeloService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Adicionar(ModeloAdicionarCommand command)
    {
        var result = _service.Adicionar(command);

        return result.Sucesso ? Ok(result) : BadRequest(result);

        /*
        if (result.Sucesso)
        {
            return Ok(result);
        }

        return BadRequest(result);
        */
    }
}