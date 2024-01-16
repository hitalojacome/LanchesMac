namespace LanchesMac.Models
{
    public class Lanche
    {
        public int LancheId { get; set; } // Chave primária da tabela de Lanche
        public string? Nome { get; set; }
        public string? DescricaoCurta { get; set; }
        public string? DescricaoDetalhada { get; set; }
        public decimal Preco { get; set; }
        public string? ImagemUrl { get; set; }
        public string? ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; } // Chave estrangeira para a tabela de categoria
        public virtual Categoria Categoria { get; set; } // Propriedade de navegação

        public Lanche(int lancheId, string? nome, string? descricaoCurta, string? descricaoDetalhada, decimal preco, string? imagemUrl, string? imagemThumbnailUrl, bool isLanchePreferido, bool emEstoque, int categoriaId, Categoria categoria)
        {
            LancheId = lancheId;
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoDetalhada = descricaoDetalhada;
            Preco = preco;
            ImagemUrl = imagemUrl;
            ImagemThumbnailUrl = imagemThumbnailUrl;
            IsLanchePreferido = isLanchePreferido;
            EmEstoque = emEstoque;
            CategoriaId = categoriaId;
            Categoria = categoria;
        }
    }
}
