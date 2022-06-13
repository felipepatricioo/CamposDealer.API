using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealer.API.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [Column("ProductId")]
        public int IdProduto { get; set; }
        [Column("Descricao")]
        [Required]
        public string DscProduto { get; set; }
        [Column("ValorUnitario")]
        [Required]
        public double VlrUnitario { get; set; }
      
    }
}
