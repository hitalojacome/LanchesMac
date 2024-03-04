using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult List()
        {
            // Chama o método Lanches do repositório para obter a lista de lanches
            //var lanches = _lancheRepository.Lanches;
            // Retorna uma View com a lista de lanches como modelo
            //return View(lanches);

            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";

            return View(lancheListViewModel);
        }
    }
}
