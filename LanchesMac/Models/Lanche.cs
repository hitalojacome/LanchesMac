using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace LanchesMac.Models;

[Table("Lanches")]
public class Lanche
{
    [Key]
    public int LancheId { get; set; } // Chave primária da tabela de Lanche

    [Required(ErrorMessage = "O nome do lanche é obrigatório!")] // NOT NULL
    [Display(Name = "Nome do Lanche")] // Como deseja que seja exibido
    [StringLength(20, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")] // Tamanho máximo suportado
    public string? Nome { get; set; }

    [Required(ErrorMessage ="A descrição do lanche é obrigatória")]
    [Display(Name ="Descrição do Lanche")]
    [StringLength(150, MinimumLength = 20, ErrorMessage = "A descrição deve ter no mínimo {0} caracteres e no máximo {1}.")]
    public string? DescricaoCurta { get; set; }

    [Required(ErrorMessage = "A descrição do lanche é obrigatória")]
    [Display(Name = "Descrição do Lanche")]
    [StringLength(300, MinimumLength = 30, ErrorMessage = "A descrição deve ter no mínimo {0} caracteres e no máximo {1}.")]
    public string? DescricaoDetalhada { get; set; }

    [Required(ErrorMessage = "O preço do lanche é obrigatório!")]
    [Display(Name ="Preço")]
    [Column(TypeName = "decimal(10,2)")] // Estipula o tipo de dado do campo
    [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
    public decimal Preco { get; set; }

    [Display(Name = "Caminho Imagem normal")]
    [StringLength(200, ErrorMessage = "O {0) deve ter no máximo {1} caracteres")]
    public string? ImagemUrl { get; set; }

    [Display(Name = "Caminho Imagem miniatura")]
    [StringLength(200, ErrorMessage = "O {0) deve ter no máximo {1} caracteres")]
    public string? ImagemThumbnailUrl { get; set; }

    [Display(Name = "Preferido?")]
    public bool IsLanchePreferido { get; set; }

    [Display(Name = "Estoque")]
    public bool EmEstoque { get; set; }

    public int CategoriaId { get; set; } // Chave estrangeira para a tabela de categoria
    public virtual Categoria? Categoria { get; set; } // Propriedade de navegação
}