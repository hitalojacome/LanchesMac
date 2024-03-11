using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        // Declaração de uma variável privada para armazenar a instância do repositório de lanches
        private readonly ILancheRepository _lancheRepository;

        // Construtor da classe LancheController que recebe uma instância de ILancheRepository
        public LancheController(ILancheRepository lancheRepository)
        {
            // Atribui o argumento recebido ao campo privado
            _lancheRepository = lancheRepository;
        }

        // Método de ação para listar os lanches
        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            
            return View(lancheListViewModel);
        }
    }
}
