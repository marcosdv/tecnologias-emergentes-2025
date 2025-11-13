namespace Garagem.Application.Entities;

public class Modelo : Entity
{
    public string Marca { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public List<Veiculo> Veiculos { get; set; } = [];
}