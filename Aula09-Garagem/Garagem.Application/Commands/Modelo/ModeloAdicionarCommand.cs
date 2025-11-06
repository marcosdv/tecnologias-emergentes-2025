using Garagem.Application.Validations;

namespace Garagem.Application.Commands.Modelo;

public class ModeloAdicionarCommand : Notificavel
{
    public string Marca { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;

    public void Validar()
    {
        if (string.IsNullOrEmpty(Marca))
        {
            AddAlerta("Campo marca do modelo é obrigatório!");
        }
        if (string.IsNullOrEmpty(Nome))
        {
            AddAlerta("Campo nome do modelo é obrigatório!");
        }
    }
}
