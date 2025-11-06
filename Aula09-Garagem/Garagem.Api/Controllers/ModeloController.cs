using Garagem.Application.Commands;
using Garagem.Application.Commands.Modelo;
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

        return TratarResult(result);
    }

    [HttpPut]
    public IActionResult Alterar(ModeloAlterarCommand command)
    {
        var result = _service.Alterar(command);

        return TratarResult(result);
    }

    [HttpDelete]
    public IActionResult Excluir(ModeloExcluirCommand command)
    {
        return TratarResult(_service.Excluir(command));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return TratarResult(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return TratarResult(_service.GetById(id));
    }

    private IActionResult TratarResult(CommandResult result)
    {
        return result.Sucesso ? Ok(result) : BadRequest(result);
    }
}