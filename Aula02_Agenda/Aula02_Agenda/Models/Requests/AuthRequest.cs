namespace Aula02_Agenda.Models.Requests;

public class AuthRequest
{
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}