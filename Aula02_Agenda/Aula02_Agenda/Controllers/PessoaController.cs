using Aula02_Agenda.Models;
using Aula02_Agenda.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aula02_Agenda.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _repository;

    public PessoaController(IPessoaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _repository.Get();
        
        if (result.Count() > 0)
        {
            return Ok(result);
        }

        return NoContent();
    }

    [HttpGet("byId/{id}")]
    public IActionResult GetById(int id)
    {
        var result = _repository.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Adicionar(Pessoa pessoa)
    {
        try
        {
            _repository.Adicionar(pessoa);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
