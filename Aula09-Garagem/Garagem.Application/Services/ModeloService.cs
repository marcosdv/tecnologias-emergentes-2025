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

    public CommandResult Alterar(ModeloAlterarCommand command)
    {
        //fail fast validation
        command.Validar();
        if (command.isInvalida)
        {
            return new CommandResult(false,
                "Dados do Modelo inválidos!", command.Alertas);
        }

        //Recuperar o modelo do banco de dados
        var modelo = _repository.GetById(command.Id);

        if (modelo == null)
        {
            return new CommandResult(false,
                "Modelo não encontrado!", command.Alertas);
        }

        modelo.Nome = command.Nome;
        modelo.Marca = command.Marca;

        _repository.Alterar(modelo);

        return new CommandResult(true,
            "Modelo alterado com sucesso!", modelo);
    }

    public CommandResult Excluir(ModeloExcluirCommand command)
    {
        //fail fast validation
        command.Validar();
        if (command.isInvalida)
        {
            return new CommandResult(false,
                "Dados do Modelo inválidos!", command.Alertas);
        }

        //Recuperar o modelo do banco de dados
        var modelo = _repository.GetById(command.Id);

        if (modelo == null)
        {
            return new CommandResult(false,
                "Modelo não encontrado!", command.Alertas);
        }

        _repository.Excluir(modelo);

        return new CommandResult(true,
            "Modelo excluído com sucesso!", modelo);
    }

    public CommandResult GetAll()
    {
        try
        {
            var result = _repository.Get();

            return new CommandResult(true, "Modelos", result);
        }
        catch (Exception ex)
        {
            return new CommandResult(false,
                "Erro ao buscar os modelos", ex);
        }
    }

    public CommandResult GetById(int id)
    {
        try
        {
            var result = _repository.GetById(id);

            return new CommandResult(true, "Modelo", result);
        }
        catch (Exception ex)
        {
            return new CommandResult(false,
                $"Erro ao buscar o modelo: {id}", ex);
        }
    }
}