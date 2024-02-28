using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        // Coleção de categorias
        IEnumerable<Categoria> Categorias { get; }
    }
}
