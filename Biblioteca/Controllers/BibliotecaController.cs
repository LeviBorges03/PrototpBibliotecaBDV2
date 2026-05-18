using Biblioteca.Models;
using Biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    readonly ILivroRepository _livroRepository;
    readonly IAutorRepository _autorRepository;

    public BibliotecaController(ILivroRepository livroRepository, IAutorRepository autorRepository)
    {
        _livroRepository = livroRepository;
        _autorRepository = autorRepository;
    }

    public async Task<IActionResult> Index()
    {
        var dbLivros = await _livroRepository.BuscarTodosLivros();

        // Simulating the static books the CodigoRef has
        List<Livro> l1 = new List<Livro>()
        {
            new Livro
            {
                Titulo = "Harry Potter",
                NumPaginas = 150,
                Autor = "Fulano",
                Genero = "Ficção Científica",
                DataPublicacao = DateOnly.MaxValue,
                CorCapa = "#1A5276"
            },
            new Livro
            {
                Titulo = "Alíce no País das Maravilhas",
                NumPaginas = 500,
                Autor = "Fulana",
                Genero = "Fantasia",
                DataPublicacao = DateOnly.MinValue,
                CorCapa = "#9B59B6"
            }
        };

        if (dbLivros != null && dbLivros.Any())
        {
            l1.AddRange(dbLivros);
        }

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

    [HttpGet]
    public IActionResult CriarLivro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CriarLivro(Livro livro)
    {
        if (ModelState.IsValid)
        {
            await _livroRepository.CriarLivroAsync(livro);
            return RedirectToAction("Index");
        }
        return View(livro);
    }

    [HttpGet]
    public IActionResult CriarAutor()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CriarAutor(Autor autor)
    {
        if (ModelState.IsValid)
        {
            _autorRepository.Add(autor);
            return RedirectToAction("Index");
        }
        return View(autor);
    }
}
