namespace Aula08_RabbitMq.Api.Models;

public class DadosVenda
{
    public int Id { get; set; }
    public string Produto { get; set; } = string.Empty;
    public double ValorUnitario { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataVenda { get; set; }
}