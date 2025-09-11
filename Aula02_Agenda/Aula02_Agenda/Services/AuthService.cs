using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aula02_Agenda.Models;
using Aula02_Agenda.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Aula02_Agenda.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;

    public AuthService(IConfiguration config)
    {
        _config = config;
    }

    private string GetRolesUsuario(AuthRequest request)
    {
        if (request.Usuario == "Marcos" && request.Senha == "123456")
        {
            return "Admin";
        }
        if (request.Usuario == "Usuario" && request.Senha == "123456")
        {
            return "User";
        }
        return "";
    }

    public AuthResponse GerarToken(AuthRequest request)
    {
        var roles = GetRolesUsuario(request);

        var validade = DateTime.Now.AddHours(1);
        var issuer = _config["Jwt:Issuer"];
        var audience = _config["Jwt:Audience"];
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var credencial = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha256);

        var claims = new[] { new Claim("role", roles) };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: validade,
            signingCredentials: credencial
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        var response = tokenHandler.WriteToken(token);
        return new AuthResponse { Token = response };
    }
}