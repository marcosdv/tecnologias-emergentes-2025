namespace Aula02_Agenda.Models.Requests;

public class TelefoneRequest
{
    public int? Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public int OpeId { get; set; }
    public int PesId { get; set; }
}