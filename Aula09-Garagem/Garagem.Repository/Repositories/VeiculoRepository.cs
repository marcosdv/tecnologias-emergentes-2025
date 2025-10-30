using Garagem.Application.Entities;
using Garagem.Application.Repositories;
using Garagem.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Garagem.Repository.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly DataContext _context;

    public VeiculoRepository(DataContext context)
    {
        _context = context;
    }

    public void Adicionar(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();
    }

    public void Alterar(Veiculo veiculo)
    {
        _context.Entry(veiculo).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Veiculo veiculo)
    {
        _context.Remove(veiculo);
        _context.SaveChanges();
    }

    public IEnumerable<Veiculo> Get()
    {
        return _context.Veiculos
            .AsNoTracking()
            .OrderBy(x => x.Modelo.Nome);
    }

    public Veiculo? GetById(int id)
    {
        return _context.Veiculos
            .Where(x => x.Id == id)
            .FirstOrDefault();
    }

    public IEnumerable<Veiculo> GetByModelo(int idModelo)
    {
        return _context.Veiculos
            .AsNoTracking()
            .Where(x => x.Modelo.Id == idModelo)
            .OrderBy(x => x.Modelo.Nome);
    }
}
