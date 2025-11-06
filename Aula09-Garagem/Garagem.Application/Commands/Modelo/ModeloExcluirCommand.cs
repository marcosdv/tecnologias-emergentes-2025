using Garagem.Application.Validations;

namespace Garagem.Application.Commands.Modelo;

public class ModeloExcluirCommand : Notificavel
{
    public int Id { get; set; }

    public void Validar()
    {
        if (Id <= 0)
        {
            AddAlerta("Campo ID do modelo é obrigatório!");
        }
    }
}