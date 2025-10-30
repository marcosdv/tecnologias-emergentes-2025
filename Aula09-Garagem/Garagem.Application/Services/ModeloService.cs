using Garagem.Application.Commands;
using Garagem.Application.Commands.Modelo;
using Garagem.Application.Entities;
using Garagem.Application.Repositories;
using Garagem.Application.Services.Interfaces;

namespace Garagem.Application.Services;

public class ModeloService : IModeloService
{
    private readonly IModeloRepository _repository;

    public ModeloService(IModeloRepository repository)
    {
        _repository = repository;
    }

    public CommandResult Adicionar(ModeloAdicionarCommand command)
    {
        //fail fast validation
        command.Validar();
        if (command.isInvalida)
        {
            return new CommandResult(false,
                "Dados do Modelo inválidos!", command.Alertas);
        }

        var modelo = new Modelo
        {
            Marca = command.Marca,
            Nome = command.Nome
        };

        _repository.Adicionar(modelo);

        return new CommandResult(true,
            "Modelo adicionado com sucesso!", modelo);
    }
}