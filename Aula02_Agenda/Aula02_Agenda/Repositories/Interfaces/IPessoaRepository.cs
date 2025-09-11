using Aula02_Agenda.Models;

namespace Aula02_Agenda.Repositories.Interfaces;

public interface IPessoaRepository
{
    IEnumerable<Pessoa> Get();
    Pessoa? GetById(int id);

    void Adicionar(Pessoa pessoa);
    void Alterar(Pessoa pessoa);
    void Excluir(int id);
}
