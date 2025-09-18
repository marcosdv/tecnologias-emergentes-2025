using Aula02_Agenda.Models.Requests;
using Aula02_Agenda.Services;
using Aula02_Agenda.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aula02_Agenda.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public IActionResult GetToken(AuthRequest request)
    {
        var result = _authService.GerarToken(request);

        return Ok(result);
    }
}