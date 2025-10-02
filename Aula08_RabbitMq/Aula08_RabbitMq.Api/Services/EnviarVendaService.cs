using System.Text.Json;
using Aula08_RabbitMq.Api.Models;
using RabbitMQ.Client;

namespace Aula08_RabbitMq.Api.Services;

public class EnviarVendaService : IEnviarVendaService
{
    public async Task Enviar(DadosVenda dadosVenda)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };

        using var connection = await factory.CreateConnectionAsync();

        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            "fila_vendas", false, false, false, null);

        var props = new BasicProperties();

        var dados = JsonSerializer.SerializeToUtf8Bytes(dadosVenda);
        
        await channel.BasicPublishAsync(
            "", "fila_vendas", false, props, dados);

        Console.WriteLine($"Mensagem enviada: {dadosVenda.Id}-{dadosVenda.Produto}");
    }
}