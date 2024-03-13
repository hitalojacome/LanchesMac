using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;
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

    public IActionResult Details(int lancheId)
    {
        var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);

        return View(lanche);
    }

    public ViewResult Search(string searchString)
    {
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;

        if (string.IsNullOrEmpty(searchString))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            categoriaAtual = "Todos os lanches";
        }
        else
        {
            lanches = _lancheRepository.Lanches
                .Where(l => l.Nome.ToLower().Contains(searchString.ToLower()));

            if (lanches.Any())
                categoriaAtual = "Lanches";
            else
                categoriaAtual = "Nenhum lanche foi encontrado";
        }

        return View("~/Views/Lanche/List.cshtml", new LancheListViewModel
        {
                Lanches= lanches,
                CategoriaAtual= categoriaAtual
        });
    }
}