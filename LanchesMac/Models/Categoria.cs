using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models;

[Table("Categorias")]
public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    [StringLength(30, ErrorMessage ="O tamanho máximo é de 30 caracteres")] // Tamanho máximo suportado
    [Required (ErrorMessage = "O nome da categoria é obrigatório!")] // NOT NULL
    [Display(Name = "Nome")] // Como deseja que seja exibido
    public string? CategoriaNome { get; set; }

    [StringLength(200, ErrorMessage = "O tamanho máximo é de 200 caracteres")]
    [Required(ErrorMessage = "A descrição da categoria é obrigatória!")]
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    public List<Lanche>? Lanches { get; set; }
}