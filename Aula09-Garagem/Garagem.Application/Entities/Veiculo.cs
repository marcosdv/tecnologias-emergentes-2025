namespace Garagem.Application.Entities;

public class Veiculo : Entity
{
    public string Placa { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int AnoFabricacao { get; set; }
    public int AnoModelo { get; set; }
    public Modelo Modelo { get; set; } = new();
}