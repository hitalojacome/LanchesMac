using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        // Cria uma instância do contexto
        public readonly AppDbContext _context;

        // Construtor com a instancia do contexto
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        // PK que será atribuido um GUID
        public string CarrinhoCompraId { get; set; }
        // Lista de itens
        public List<CarrinhoCompraItem>? CarrinhoCompraItens { get; set; }
    }
}
