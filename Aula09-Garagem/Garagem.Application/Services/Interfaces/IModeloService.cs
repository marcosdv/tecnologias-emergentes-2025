using Garagem.Application.Commands;
using Garagem.Application.Commands.Modelo;

namespace Garagem.Application.Services.Interfaces;

public interface IModeloService
{
    CommandResult Adicionar(ModeloAdicionarCommand command);
}
