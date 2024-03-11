using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.Repositories;
public class CategoriaRepository : ICategoriaRepository
{
    // Atributo _context do tipo AppDbContext somente leitura.
    private readonly AppDbContext _context;

    // Construtor da classe, recebe um parametro do tipo AppDbContext
    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    // Implementação da Interface
        // Retorna uma coleção de categorias
    public IEnumerable<Categoria> Categorias => _context.Categorias; // Expression Bodied Member
}
