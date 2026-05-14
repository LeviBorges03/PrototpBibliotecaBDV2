using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _context;

        public LivroRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> BuscarTodosLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<bool> CriarLivroAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
