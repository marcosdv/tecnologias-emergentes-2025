using Garagem.Application.Entities;

namespace Garagem.Application.Repositories;

public interface IVeiculoRepository
{
    Veiculo? GetById(int id);
    IEnumerable<Veiculo> Get();
    IEnumerable<Veiculo> GetByModelo(int idModelo);

    void Adicionar(Veiculo veiculo);
    void Alterar(Veiculo veiculo);
    void Excluir(Veiculo veiculo);
}