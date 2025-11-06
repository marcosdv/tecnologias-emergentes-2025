using Garagem.Application.Commands;
using Garagem.Application.Commands.Modelo;

namespace Garagem.Application.Services.Interfaces;

public interface IModeloService
{
    CommandResult Adicionar(ModeloAdicionarCommand command);
    CommandResult Alterar(ModeloAlterarCommand command);
    CommandResult Excluir(ModeloExcluirCommand command);

    CommandResult GetAll();
    CommandResult GetById(int id);
}
