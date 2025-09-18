using Aula02_Agenda.Models.Entities;
using Aula02_Agenda.Models.Requests;
using Aula02_Agenda.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Aula02_Agenda.Controllers;

[Authorize(Roles = "Admin,User")]
[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaRepository _repository;
    private readonly IMemoryCache _memoryCache;

    public PessoaController(IPessoaRepository repository, IMemoryCache memoryCache)
    {
        _repository = repository;
        _memoryCache = memoryCache;
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        var cacheKey = "pessoas";
        List<Pessoa>? lista;

        var existeCache = _memoryCache.TryGetValue(cacheKey, out lista);

        if (!existeCache)
        {
            lista = _repository.Get().ToList();

            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            _memoryCache.Set(cacheKey, lista, options);
        }

        if (lista?.Count() > 0)
        {
            return Ok(lista);
        }

        return NoContent();
    }

    [AllowAnonymous]
    [HttpGet("byId/{id}")]
    public IActionResult GetById(int id)
    {
        var result = _repository.GetById(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Adicionar(PessoaRequest request)
    {
        try
        {
            var pessoa = new Pessoa(0, request.Nome);
            _repository.Adicionar(pessoa);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPut]
    public IActionResult Alterar(PessoaRequest request)
    {
        try
        {
            var pessoa = new Pessoa(request.Id ?? 0, request.Nome);
            _repository.Alterar(pessoa);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        try
        {
            _repository.Excluir(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
}
