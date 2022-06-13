using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposDealer.API.Models
{
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        public int IdCliente { get; set; }
        [Column("NmCliente")]
        [Required]
        public string NmCliente { get; set; }
        [Column("Cidade")]
        [Required]
        public string Cidade { get; set; }

    }
}
