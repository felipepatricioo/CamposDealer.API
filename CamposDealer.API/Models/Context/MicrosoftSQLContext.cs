

using Microsoft.EntityFrameworkCore;

namespace CamposDealer.API.Models.Context
{
    public class MicrosoftSQLContext : DbContext
    {
        public MicrosoftSQLContext( DbContextOptions<MicrosoftSQLContext> options) :base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Venda> Vendas { get; set; }

    }
}
