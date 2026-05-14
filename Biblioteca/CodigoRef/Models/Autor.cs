namespace Biblioteca.Models;

public class Autor
{
    public int Id {get; set;}
    public string Nome {get; set; }
    public string Bibliografia {get; set; }
    public DateOnly DataNascimento {get; set; }
    public DateOnly? DataMorte {get; set; }
}