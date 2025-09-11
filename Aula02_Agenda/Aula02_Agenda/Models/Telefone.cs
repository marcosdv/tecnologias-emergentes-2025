namespace Aula02_Agenda.Models;

public class Telefone
{
    #region | Propriedades |

    public int Id { get; set; }
    public string Numero { get; set; }
    public Operadora Operadora { get; set; }

    #endregion

    #region | Construtor |

    public Telefone(int id, string numero, Operadora operadora)
    {
        Id = id;
        Numero = numero;
        Operadora = operadora;
    }

    #endregion
}