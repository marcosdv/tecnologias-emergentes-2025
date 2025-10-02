using Aula08_RabbitMq.Api.Models;

namespace Aula08_RabbitMq.Api.Services;

public interface IEnviarVendaService
{
    Task Enviar(DadosVenda dadosVenda);
}