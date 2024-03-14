using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMac.Controllers;

public class PedidoController : Controller
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
    {
        _pedidoRepository = pedidoRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Pedido pedido)
    {
        int totalItensPedido = 0;
        decimal precoTotalPedido = 0.0m;

        // Obter os itens do carrinho de compra
        List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItens = itens;

        // Verifica se existem itens no pedido
        if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
        {
            ModelState.AddModelError("", "Carrinho vazio.");
        }

        // Calcula o total de itens e o total do pedido
        foreach (var item in itens)
        {
            totalItensPedido += item.Quantidade;
            precoTotalPedido += (item.Lanche.Preco * item.Quantidade);
        }

        // Atribui os valores obtidos ao pedido
        pedido.TotalItensPedido = totalItensPedido;
        pedido.PedidoTotal = precoTotalPedido;

        // Valida os dados do pedido
        if (ModelState.IsValid)
        {
            // Cria um pedido e seus detalhes
            _pedidoRepository.CriarPedido(pedido);

            // Define mensagens ao cliente
            ViewBag.CheckoutCompletoMensagem = "Agradecemos pelo seu pedido! :D";
            ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

            // Limpa o carrinho
            _carrinhoCompra.LimparCarrinho();

            // Exibe a view com dados do cliente e do pedido
            return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
        }
        return View(pedido);
    }
}