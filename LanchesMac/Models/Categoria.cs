namespace LanchesMac.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? CategoriaNome { get; set; }
        public string? Descricao { get; set; }
        public List<Lanche>? Lanches { get; set; }

        public Categoria(int categoriaId, string? categoriaNome, string? descricao, List<Lanche>? lanches)
        {
            CategoriaId = categoriaId;
            CategoriaNome = categoriaNome;
            Descricao = descricao;
            Lanches = lanches;
        }
    }
}
