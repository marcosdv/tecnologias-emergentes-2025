using Garagem.Application.Entities;

namespace Garagem.Application.Repositories;

public interface IModeloRepository
{
    Modelo? GetById(int id);
    List<Modelo> Get();

    void Adicionar(Modelo modelo);
    void Alterar(Modelo modelo);
    void Excluir(Modelo modelo);
}