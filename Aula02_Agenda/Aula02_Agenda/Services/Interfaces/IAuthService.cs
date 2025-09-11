using Aula02_Agenda.Models;

namespace Aula02_Agenda.Services.Interfaces;

public interface IAuthService
{
    AuthResponse GerarToken(AuthRequest request);
}
