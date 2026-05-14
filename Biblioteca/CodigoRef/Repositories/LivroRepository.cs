using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositories;

public class LivroRepository : ILivroRepository
{
    readonly BibliotecaContext _context;

    public LivroRepository(BibliotecaContext context)
    {
        _context = context;
    }

    public async Task<List<Livro>> BuscarTodosLivrosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<bool> CriarLivroAsync(Livro livro)
    {
        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();
        return true;
    }
}

public interface ILivroRepository
{
    Task<List<Livro>> BuscarTodosLivrosAsync();
    Task<bool> CriarLivroAsync(Livro livro);
}