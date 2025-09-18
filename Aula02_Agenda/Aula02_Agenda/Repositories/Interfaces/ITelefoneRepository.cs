using Aula02_Agenda.Models.Entities;
using Aula02_Agenda.Models.Requests;

namespace Aula02_Agenda.Repositories.Interfaces;

public interface ITelefoneRepository
{
    IEnumerable<Telefone> Get();
    Telefone? GetById(int id);

    void Adicionar(TelefoneRequest telefone);
    void Alterar(TelefoneRequest telefone);
    void Excluir(int id);
}