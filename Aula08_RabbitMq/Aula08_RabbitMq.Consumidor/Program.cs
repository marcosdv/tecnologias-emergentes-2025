using System.Text;
using System.Text.Json;
using Aula08_RabbitMq.Consumidor.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Aguardando mensagens...\n");

var factory = new ConnectionFactory { HostName = "localhost" };

using var connection = await factory.CreateConnectionAsync();

using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync("fila_vendas", false, false, false);

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += (sender, args) =>
{
    var dados = args.Body.ToArray();
    var json = Encoding.UTF8.GetString(dados);
    var mensagem = JsonSerializer.Deserialize<DadosVenda>(json);

    Console.WriteLine($"Mensagem recebida: {mensagem?.Id}");
    Console.WriteLine($"Json: {json}\n");

    return Task.CompletedTask;
};

await channel.BasicConsumeAsync("fila_vendas", true, consumer);

Console.ReadLine();