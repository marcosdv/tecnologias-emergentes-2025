using Garagem.Application.Entities;
using Garagem.Application.Repositories;
using Garagem.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Garagem.Repository.Repositories;

public class ModeloRepository : IModeloRepository
{
    private readonly DataContext _context;

    public ModeloRepository(DataContext context)
    {
        _context = context;
    }

    public void Adicionar(Modelo modelo)
    {
        _context.Modelos.Add(modelo);
        _context.SaveChanges();
    }

    public void Alterar(Modelo modelo)
    {
        _context.Entry(modelo).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Excluir(Modelo modelo)
    {
        _context.Remove(modelo);
        _context.SaveChanges();
    }

    public IEnumerable<Modelo> Get()
    {
        return _context.Modelos
            .AsNoTracking()
            .OrderBy(x => x.Marca);
    }

    public Modelo? GetById(int id)
    {
        return _context.Modelos
            .Where(x => x.Id == id)
            .FirstOrDefault();
    }
}
