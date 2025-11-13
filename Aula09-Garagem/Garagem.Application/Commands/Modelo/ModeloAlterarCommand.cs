using Garagem.Application.Validations;

namespace Garagem.Application.Commands.Modelo;

public class ModeloAlterarCommand : Notificavel
{
    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;

    public void Validar()
    {
        if (Id <= 0)
        {
            AddAlerta("Campo ID do modelo é obrigatório!");
        }
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
