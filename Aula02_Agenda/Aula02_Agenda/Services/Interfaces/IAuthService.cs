using Aula02_Agenda.Models.Requests;
using Aula02_Agenda.Models.Responses;

namespace Aula02_Agenda.Services.Interfaces;

public interface IAuthService
{
    AuthResponse GerarToken(AuthRequest request);
}
