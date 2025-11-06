namespace Garagem.Application.Validations;

public abstract class Notificavel
{
    private readonly List<string> _alertas;

    public Notificavel()
    {
        _alertas = [];
    }

    public void AddAlerta(string mensagem)
    {
        _alertas.Add(mensagem);
    }

    public IReadOnlyCollection<string> Alertas => _alertas;

    public bool isInvalida => _alertas.Any();

    public bool isValida => !isInvalida;
}
