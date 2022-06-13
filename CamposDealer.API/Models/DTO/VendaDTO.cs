namespace CamposDealer.API.Models.DTO
{
    public class VendaDTO
    {
        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int QtdVenda { get; set; }
        public double VlrUnitarioVenda { get; set; }
    }
}
