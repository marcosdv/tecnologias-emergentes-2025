using Aula08_RabbitMq.Api.Models;
using Aula08_RabbitMq.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aula08_RabbitMq.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendasController : ControllerBase
{
    private readonly IEnviarVendaService _service;

    public VendasController(IEnviarVendaService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Enviar(DadosVenda dadosVenda)
    {
        try
        {
            _service.Enviar(dadosVenda);
            
            return Ok("Mensagem enviada com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao enviar: {ex.Message}");
        }
    }
}