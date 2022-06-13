using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealer.API.Models
{
    public class Venda
    {
        [Key]
        [Column("Id")]
        public int IdVenda { get; set; }
        [ForeignKey("IdCliente")]
        [Required]
        public int IdCliente { get; set; }
        [ForeignKey("IdProduto")]
        [Required]
        public int IdProduto { get; set; }
        [Column("QtdVenda")]
        [Required]
        public int QtdVenda { get; set; }
        [Column("VlrUnitarioVenda")]
        [Required]
        public double VlrUnitarioVenda { get; set; }
        [Column("DthVenda")]
        [Required]
        public DateTime DthVenda { get; set; }
        [Column("VlrTotalVenda")]
        [Required]
        public double VlrTotalVenda { get; set; }
    }
}
