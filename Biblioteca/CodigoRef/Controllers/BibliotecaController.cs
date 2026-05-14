using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    readonly ILivroRepository _livroRepository;

    public BibliotecaController(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public IActionResult Index()
    {
        List<Livro> l1 = new List<Livro>()
        {
            new Livro
            {
                Titulo = "Harry Potter",
                NumPaginas = 150,
                Autor = "Fulano",
                Genero = "Ficção Científica",
                DataPublicacao = DateOnly.MaxValue   
            },
            new Livro
            {
                Titulo = "Alíce no País das Maravilhas",
                NumPaginas = 500,
                Autor = "Fulana",
                Genero = "Fantasia",
                DataPublicacao = DateOnly.MinValue
            }
        };

        return View(l1);
    }

    public IActionResult Livro()
    {
        return View();
    }

    public IActionResult Autor()
    {
        return View();
    }

    public IActionResult CriarLivro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarLivroAsync(Livro livro)
    {
        await _livroRepository.CriarLivroAsync(livro);
        return RedirectToAction("CriarLivro");
    }
}