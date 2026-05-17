using System.Collections.Generic;
using Biblioteca.Models;

namespace Biblioteca.Repositories;

public interface IAutorRepository
{
    IEnumerable<Autor> GetAll();
    Autor? GetById(int id);
    void Add(Autor autor);
    void Update(Autor autor);
    void Delete(int id);
}
