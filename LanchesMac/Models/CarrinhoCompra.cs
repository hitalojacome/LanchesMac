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

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            // Define uma sessão
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            // Obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            // Obtem ou gera o Id do carrinho
            var carrinhoId = session?.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            // Atribui o id do carrinho na sessão
            session?.SetString("CarrinhoId", carrinhoId);

            // Retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };

        }
    }
}
