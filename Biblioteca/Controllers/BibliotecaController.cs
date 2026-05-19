using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biblioteca.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Controllers;

public class BibliotecaController : Controller
{
    private readonly ILivroRepository _livroRepository;
    private readonly IAutorRepository _autorRepository;

    public BibliotecaController(ILivroRepository livroRepository, IAutorRepository autorRepository)
    {
        _livroRepository = livroRepository;
        _autorRepository = autorRepository;
    }

    private List<Livro> GetLivrosDefault()
    {
        return new List<Livro>
        {
            new Livro { Titulo = "O Alquimista", Autor = "Paulo Coelho", Genero = "Ficção", NumPaginas = 208, DataPublicacao = new DateOnly(1988, 1, 1), CorCapa = "#D4AF37" },
            new Livro { Titulo = "Harry Potter and the Prisoner of Azkaban", Autor = "J.K. Rowling", Genero = "Fantasia", NumPaginas = 317, DataPublicacao = new DateOnly(1999, 7, 8), CorCapa = "#4A235A" },
            new Livro { Titulo = "Dom Casmurro", Autor = "Machado de Assis", Genero = "Romance", NumPaginas = 256, DataPublicacao = new DateOnly(1899, 1, 1), CorCapa = "#2C3E50" },
            new Livro { Titulo = "A Culpa é das Estrelas", Autor = "John Green", Genero = "Romance", NumPaginas = 313, DataPublicacao = new DateOnly(2012, 1, 10), CorCapa = "#3498DB" },
            new Livro { Titulo = "A Moreninha", Autor = "Joaquim Manuel de Macedo", Genero = "Romance", NumPaginas = 180, DataPublicacao = new DateOnly(1844, 1, 1), CorCapa = "#E74C3C" },
            new Livro { Titulo = "Alice no País das Maravilhas", Autor = "Lewis Carroll", Genero = "Fantasia", NumPaginas = 352, DataPublicacao = new DateOnly(1865, 11, 26), CorCapa = "#9B59B6" },
            new Livro { Titulo = "As Aventuras de Pinóquio", Autor = "Carlo Collodi", Genero = "Infantil", NumPaginas = 192, DataPublicacao = new DateOnly(1883, 1, 1), CorCapa = "#F1C40F" },
            new Livro { Titulo = "Memórias Póstumas de Brás Cubas", Autor = "Machado de Assis", Genero = "Romance", NumPaginas = 352, DataPublicacao = new DateOnly(1881, 1, 1), CorCapa = "#34495E" },
            new Livro { Titulo = "O Hobbit", Autor = "J.R.R. Tolkien", Genero = "Fantasia", NumPaginas = 310, DataPublicacao = new DateOnly(1937, 9, 21), CorCapa = "#27AE60" },
            new Livro { Titulo = "O Mágico de Oz", Autor = "L. Frank Baum", Genero = "Fantasia", NumPaginas = 272, DataPublicacao = new DateOnly(1900, 5, 17), CorCapa = "#1ABC9C" },
            new Livro { Titulo = "O Pequeno Príncipe", Autor = "Antoine de Saint-Exupéry", Genero = "Infantil", NumPaginas = 96, DataPublicacao = new DateOnly(1943, 4, 6), CorCapa = "#F39C12" },
            new Livro { Titulo = "O Senhor dos Anéis", Autor = "J.R.R. Tolkien", Genero = "Fantasia", NumPaginas = 1216, DataPublicacao = new DateOnly(1954, 7, 29), CorCapa = "#5D6D7E" },
            new Livro { Titulo = "1984", Autor = "George Orwell", Genero = "Distopia", NumPaginas = 328, DataPublicacao = new DateOnly(1949, 6, 8), CorCapa = "#17202A" },
            new Livro { Titulo = "O Conde de Monte Cristo", Autor = "Alexandre Dumas", Genero = "Aventura", NumPaginas = 1312, DataPublicacao = new DateOnly(1844, 8, 28), CorCapa = "#7B241C" },
            new Livro { Titulo = "Crime e Castigo", Autor = "Fiódor Dostoiévski", Genero = "Ficção Psicológica", NumPaginas = 608, DataPublicacao = new DateOnly(1866, 1, 1), CorCapa = "#4A235A" },
            new Livro { Titulo = "Os Miseráveis", Autor = "Victor Hugo", Genero = "Romance Histórico", NumPaginas = 1512, DataPublicacao = new DateOnly(1862, 1, 1), CorCapa = "#1A5276" },
            new Livro { Titulo = "Moby Dick", Autor = "Herman Melville", Genero = "Aventura", NumPaginas = 720, DataPublicacao = new DateOnly(1851, 10, 18), CorCapa = "#1F618D" },
            new Livro { Titulo = "A Divina Comédia", Autor = "Dante Alighieri", Genero = "Épico", NumPaginas = 798, DataPublicacao = new DateOnly(1320, 1, 1), CorCapa = "#E67E22" },
            new Livro { Titulo = "Orgulho e Preconceito", Autor = "Jane Austen", Genero = "Romance", NumPaginas = 432, DataPublicacao = new DateOnly(1813, 1, 28), CorCapa = "#F5B041" },
            new Livro { Titulo = "Anna Karenina", Autor = "Liev Tolstói", Genero = "Romance", NumPaginas = 864, DataPublicacao = new DateOnly(1877, 1, 1), CorCapa = "#922B21" },
            new Livro { Titulo = "O Morro dos Ventos Uivantes", Autor = "Emily Brontë", Genero = "Romance Gótico", NumPaginas = 400, DataPublicacao = new DateOnly(1847, 12, 1), CorCapa = "#4D5656" },
            new Livro { Titulo = "Jane Eyre", Autor = "Charlotte Brontë", Genero = "Romance", NumPaginas = 500, DataPublicacao = new DateOnly(1847, 10, 16), CorCapa = "#7D6608" },
            new Livro { Titulo = "Grandes Esperanças", Autor = "Charles Dickens", Genero = "Ficção", NumPaginas = 544, DataPublicacao = new DateOnly(1861, 1, 1), CorCapa = "#196F3D" },
            new Livro { Titulo = "A Odisseia", Autor = "Homero", Genero = "Épico", NumPaginas = 541, DataPublicacao = new DateOnly(800, 1, 1), CorCapa = "#154360" },
            new Livro { Titulo = "Ilíada", Autor = "Homero", Genero = "Épico", NumPaginas = 704, DataPublicacao = new DateOnly(750, 1, 1), CorCapa = "#78281F" },
            new Livro { Titulo = "Hamlet", Autor = "William Shakespeare", Genero = "Tragédia", NumPaginas = 342, DataPublicacao = new DateOnly(1603, 1, 1), CorCapa = "#17202A" },
            new Livro { Titulo = "Dom Quixote", Autor = "Miguel de Cervantes", Genero = "Romance", NumPaginas = 1072, DataPublicacao = new DateOnly(1605, 1, 1), CorCapa = "#D35400" },
            new Livro { Titulo = "A Metamorfose", Autor = "Franz Kafka", Genero = "Ficção Absurda", NumPaginas = 201, DataPublicacao = new DateOnly(1915, 10, 1), CorCapa = "#2C3E50" },
            new Livro { Titulo = "O Grande Gatsby", Autor = "F. Scott Fitzgerald", Genero = "Tragédia", NumPaginas = 218, DataPublicacao = new DateOnly(1925, 4, 10), CorCapa = "#F1C40F" },
            new Livro { Titulo = "Os Irmãos Karamazov", Autor = "Fiódor Dostoiévski", Genero = "Filosofia", NumPaginas = 824, DataPublicacao = new DateOnly(1880, 11, 1), CorCapa = "#7D3C98" },
            new Livro { Titulo = "O Retrato de Dorian Gray", Autor = "Oscar Wilde", Genero = "Gótico", NumPaginas = 254, DataPublicacao = new DateOnly(1890, 7, 1), CorCapa = "#8E44AD" },
            new Livro { Titulo = "Guerra e Paz", Autor = "Liev Tolstói", Genero = "Ficção Histórica", NumPaginas = 1225, DataPublicacao = new DateOnly(1869, 1, 1), CorCapa = "#273746" },
            new Livro { Titulo = "Cem Anos de Solidão", Autor = "Gabriel García Márquez", Genero = "Realismo Mágico", NumPaginas = 417, DataPublicacao = new DateOnly(1967, 5, 30), CorCapa = "#E67E22" },
            new Livro { Titulo = "Em Busca do Tempo Perdido", Autor = "Marcel Proust", Genero = "Modernismo", NumPaginas = 4211, DataPublicacao = new DateOnly(1913, 1, 1), CorCapa = "#D4E6F1" },
            new Livro { Titulo = "O Estrangeiro", Autor = "Albert Camus", Genero = "Filosofia", NumPaginas = 123, DataPublicacao = new DateOnly(1942, 1, 1), CorCapa = "#F4D03F" },
            new Livro { Titulo = "Ulysses", Autor = "James Joyce", Genero = "Modernismo", NumPaginas = 730, DataPublicacao = new DateOnly(1922, 2, 2), CorCapa = "#5D6D7E" },
            new Livro { Titulo = "A Montanha Mágica", Autor = "Thomas Mann", Genero = "Ficção Filosófica", NumPaginas = 706, DataPublicacao = new DateOnly(1924, 1, 1), CorCapa = "#BFC9CA" },
            new Livro { Titulo = "Fahrenheit 451", Autor = "Ray Bradbury", Genero = "Distopia", NumPaginas = 249, DataPublicacao = new DateOnly(1953, 10, 19), CorCapa = "#E74C3C" },
            new Livro { Titulo = "Admirável Mundo Novo", Autor = "Aldous Huxley", Genero = "Distopia", NumPaginas = 268, DataPublicacao = new DateOnly(1932, 1, 1), CorCapa = "#85C1E9" },
            new Livro { Titulo = "O Lobo da Estepe", Autor = "Hermann Hesse", Genero = "Romance Psicológico", NumPaginas = 237, DataPublicacao = new DateOnly(1927, 1, 1), CorCapa = "#34495E" },
            new Livro { Titulo = "O Som e a Fúria", Autor = "William Faulkner", Genero = "Gótico do Sul", NumPaginas = 326, DataPublicacao = new DateOnly(1929, 10, 7), CorCapa = "#AF7AC5" },
            new Livro { Titulo = "Coração de Trevas", Autor = "Joseph Conrad", Genero = "Aventura", NumPaginas = 116, DataPublicacao = new DateOnly(1899, 2, 1), CorCapa = "#17202A" },
            new Livro { Titulo = "A Revolução dos Bichos", Autor = "George Orwell", Genero = "Sátira", NumPaginas = 112, DataPublicacao = new DateOnly(1945, 8, 17), CorCapa = "#E59866" },
            new Livro { Titulo = "Madame Bovary", Autor = "Gustave Flaubert", Genero = "Realismo", NumPaginas = 328, DataPublicacao = new DateOnly(1857, 1, 1), CorCapa = "#F1948A" },
            new Livro { Titulo = "O Processo", Autor = "Franz Kafka", Genero = "Ficção Absurda", NumPaginas = 255, DataPublicacao = new DateOnly(1925, 1, 1), CorCapa = "#7F8C8D" },
            new Livro { Titulo = "O Apanhador no Campo de Centeio", Autor = "J.D. Salinger", Genero = "Romance de Formação", NumPaginas = 277, DataPublicacao = new DateOnly(1951, 7, 16), CorCapa = "#F5B041" },
            new Livro { Titulo = "Vinte Mil Léguas Submarinas", Autor = "Júlio Verne", Genero = "Ficção Científica", NumPaginas = 400, DataPublicacao = new DateOnly(1870, 1, 1), CorCapa = "#2E86C1" },
            new Livro { Titulo = "Viagem ao Centro da Terra", Autor = "Júlio Verne", Genero = "Ficção Científica", NumPaginas = 254, DataPublicacao = new DateOnly(1864, 11, 25), CorCapa = "#C0392B" },
            new Livro { Titulo = "A Ilha do Tesouro", Autor = "Robert Louis Stevenson", Genero = "Aventura", NumPaginas = 240, DataPublicacao = new DateOnly(1883, 5, 23), CorCapa = "#D4AC0D" },
            new Livro { Titulo = "O Médico e o Monstro", Autor = "Robert Louis Stevenson", Genero = "Gótico", NumPaginas = 144, DataPublicacao = new DateOnly(1886, 1, 5), CorCapa = "#1B2631" },
            new Livro { Titulo = "Frankenstein", Autor = "Mary Shelley", Genero = "Gótico", NumPaginas = 280, DataPublicacao = new DateOnly(1818, 1, 1), CorCapa = "#4A235A" },
            new Livro { Titulo = "Drácula", Autor = "Bram Stoker", Genero = "Gótico", NumPaginas = 418, DataPublicacao = new DateOnly(1897, 5, 26), CorCapa = "#641E16" },
            new Livro { Titulo = "Ensaio sobre a Cegueira", Autor = "José Saramago", Genero = "Alegoria", NumPaginas = 310, DataPublicacao = new DateOnly(1995, 1, 1), CorCapa = "#F2F3F4" },
            new Livro { Titulo = "Os Sertões", Autor = "Euclides da Cunha", Genero = "Crônica", NumPaginas = 630, DataPublicacao = new DateOnly(1902, 1, 1), CorCapa = "#9C640C" },
            new Livro { Titulo = "Vidas Secas", Autor = "Graciliano Ramos", Genero = "Romance", NumPaginas = 128, DataPublicacao = new DateOnly(1938, 1, 1), CorCapa = "#E67E22" },
            new Livro { Titulo = "Grande Sertão: Veredas", Autor = "João Guimarães Rosa", Genero = "Romance", NumPaginas = 600, DataPublicacao = new DateOnly(1956, 1, 1), CorCapa = "#229954" },
            new Livro { Titulo = "A Hora da Estrela", Autor = "Clarice Lispector", Genero = "Romance", NumPaginas = 87, DataPublicacao = new DateOnly(1977, 1, 1), CorCapa = "#8E44AD" },
            new Livro { Titulo = "Macunaíma", Autor = "Mário de Andrade", Genero = "Modernismo", NumPaginas = 208, DataPublicacao = new DateOnly(1928, 1, 1), CorCapa = "#2E4053" },
            new Livro { Titulo = "Iracema", Autor = "José de Alencar", Genero = "Romance", NumPaginas = 140, DataPublicacao = new DateOnly(1865, 1, 1), CorCapa = "#27AE60" },
            new Livro { Titulo = "O Cortiço", Autor = "Aluísio Azevedo", Genero = "Naturalismo", NumPaginas = 264, DataPublicacao = new DateOnly(1890, 1, 1), CorCapa = "#873600" },
            new Livro { Titulo = "Capitães da Areia", Autor = "Jorge Amado", Genero = "Romance", NumPaginas = 288, DataPublicacao = new DateOnly(1937, 1, 1), CorCapa = "#D68910" },
            new Livro { Titulo = "O Auto da Compadecida", Autor = "Ariano Suassuna", Genero = "Comédia", NumPaginas = 208, DataPublicacao = new DateOnly(1955, 1, 1), CorCapa = "#F4D03F" },
            new Livro { Titulo = "Memórias de um Sargento de Milícias", Autor = "Manuel Antônio de Almeida", Genero = "Romance", NumPaginas = 304, DataPublicacao = new DateOnly(1854, 1, 1), CorCapa = "#5D6D7E" },
            new Livro { Titulo = "Noites Brancas", Autor = "Fiódor Dostoiévski", Genero = "Romance", NumPaginas = 96, DataPublicacao = new DateOnly(1848, 1, 1), CorCapa = "#AED6F1" },
            new Livro { Titulo = "O Idiota", Autor = "Fiódor Dostoiévski", Genero = "Filosofia", NumPaginas = 688, DataPublicacao = new DateOnly(1869, 1, 1), CorCapa = "#839192" },
            new Livro { Titulo = "Lolita", Autor = "Vladimir Nabokov", Genero = "Ficção", NumPaginas = 336, DataPublicacao = new DateOnly(1955, 9, 1), CorCapa = "#F1948A" },
            new Livro { Titulo = "A Náusea", Autor = "Jean-Paul Sartre", Genero = "Filosofia", NumPaginas = 253, DataPublicacao = new DateOnly(1938, 1, 1), CorCapa = "#BFC9CA" },
            new Livro { Titulo = "Os Lusiadas", Autor = "Luís Vaz de Camões", Genero = "Épico", NumPaginas = 400, DataPublicacao = new DateOnly(1572, 1, 1), CorCapa = "#C39BD3" },
            new Livro { Titulo = "O Primo Basílio", Autor = "Eça de Queirós", Genero = "Realismo", NumPaginas = 488, DataPublicacao = new DateOnly(1878, 1, 1), CorCapa = "#7D6608" },
            new Livro { Titulo = "A Relíquia", Autor = "Eça de Queirós", Genero = "Romance", NumPaginas = 320, DataPublicacao = new DateOnly(1887, 1, 1), CorCapa = "#A04000" },
            new Livro { Titulo = "Sagarana", Autor = "João Guimarães Rosa", Genero = "Contos", NumPaginas = 384, DataPublicacao = new DateOnly(1946, 1, 1), CorCapa = "#58D68D" },
            new Livro { Titulo = "Laços de Família", Autor = "Clarice Lispector", Genero = "Contos", NumPaginas = 136, DataPublicacao = new DateOnly(1960, 1, 1), CorCapa = "#EC7063" },
            new Livro { Titulo = "O Nome da Rosa", Autor = "Umberto Eco", Genero = "Mistério Histórico", NumPaginas = 512, DataPublicacao = new DateOnly(1980, 1, 1), CorCapa = "#7E5109" },
            new Livro { Titulo = "O Corvo", Autor = "Edgar Allan Poe", Genero = "Poesia Gótica", NumPaginas = 48, DataPublicacao = new DateOnly(1845, 1, 29), CorCapa = "#1B2631" },
            new Livro { Titulo = "Ensaio sobre a Lucidez", Autor = "José Saramago", Genero = "Alegoria", NumPaginas = 328, DataPublicacao = new DateOnly(2004, 1, 1), CorCapa = "#D35400" },
            new Livro { Titulo = "A Peste", Autor = "Albert Camus", Genero = "Filosofia", NumPaginas = 308, DataPublicacao = new DateOnly(1947, 1, 1), CorCapa = "#922B21" }};
    }

    public async Task<IActionResult> Index()
    {
        var dbLivros = await _livroRepository.BuscarTodosLivros();

        var combinedLivros = GetLivrosDefault();
        if (dbLivros != null && dbLivros.Any())
        {
            combinedLivros.AddRange(dbLivros);
        }

        var livrosOrdenados = combinedLivros.OrderByDescending(l => l.DataPublicacao).ToList();
        return View(livrosOrdenados);
    }

    public async Task<IActionResult> Livro(string titulo)
    {
        Livro model = new Livro();

        if (!string.IsNullOrEmpty(titulo))
        {
            var dbLivros = await _livroRepository.BuscarTodosLivros();
            var dbMatch = dbLivros?.FirstOrDefault(l => l.Titulo != null && l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (dbMatch != null)
            {
                model = dbMatch;
            }
            else
            {
                var localMatch = GetLivrosDefault().FirstOrDefault(l => l.Titulo != null && l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
                if (localMatch != null)
                {
                    model = localMatch;
                }
            }
        }

        return View(model);
    }

    public async Task<IActionResult> Autor(string nome)
    {
        Autor model = new Autor { DataNascimento = DateOnly.FromDateTime(DateTime.Now) };
        if (!string.IsNullOrEmpty(nome))
        {
            var dbAutores = _autorRepository.GetAll();
            var dbMatch = dbAutores?.FirstOrDefault(a => a.Nome != null && a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (dbMatch != null)
            {
                model = dbMatch;
                var dbLivros = await _livroRepository.BuscarTodosLivros();
                var combinedLivros = GetLivrosDefault();
                if (dbLivros != null && dbLivros.Any()) combinedLivros.AddRange(dbLivros);

                model.Livros = combinedLivros.Where(l => l.Autor != null && l.Autor.Equals(nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                model.Nome = nome;
                model.Biografia = "Biografia não disponível no momento.";

                var dbLivros = await _livroRepository.BuscarTodosLivros();
                var combinedLivros = GetLivrosDefault();
                if (dbLivros != null && dbLivros.Any()) combinedLivros.AddRange(dbLivros);

                model.Livros = combinedLivros.Where(l => l.Autor != null && l.Autor.Equals(nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        return View(model);
    }

    public IActionResult CriarLivro()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CriarAutor()
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
