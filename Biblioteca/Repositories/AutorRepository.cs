using Biblioteca.Models;

namespace Biblioteca.Repositories;

public class AutorRepository : IAutorRepository
{
    readonly BibliotecaContext _context;

    public AutorRepository(BibliotecaContext context)
    {
        _context = context;
    }

    public IEnumerable<Autor> GetAll()
    {
        return _context.Autores.ToList();
    }

    public Autor? GetById(int id)
    {
        return _context.Autores.FirstOrDefault(a => a.Id == id);
    }

    public void Add(Autor autor)
    {
        _context.Autores.Add(autor);
        _context.SaveChanges();
    }

    public void Update(Autor autor)
    {
        _context.Autores.Update(autor);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var autor = _context.Autores.FirstOrDefault(a => a.Id == id);
        if (autor != null)
        {
            _context.Autores.Remove(autor);
            _context.SaveChanges();
        }
    }
}
