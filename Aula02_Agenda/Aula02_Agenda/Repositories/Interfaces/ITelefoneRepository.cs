using Aula02_Agenda.Models;

namespace Aula02_Agenda.Repositories.Interfaces;

public interface ITelefoneRepository
{
    IEnumerable<Telefone> Get();
    Telefone? GetById(int id);

    void Adicionar(Telefone telefone);
    void Alterar(Telefone telefone);
    void Excluir(int id);
}