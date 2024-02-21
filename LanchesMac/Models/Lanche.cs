namespace LanchesMac.Models;
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
}
