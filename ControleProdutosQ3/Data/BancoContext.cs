using ControleProdutosQ3.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleProdutosQ3.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        { 
        }

        public DbSet<ProdutoModel> Produto {  get; set; }

        public DbSet<ClienteModel> Cliente { get; set; }

        public DbSet<LoginModel> Login { get; set; }   

        public DbSet<EnderecoModel> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>().HasMany(e => e.Enderecos).WithOne(e => e.Cliente).HasForeignKey(e => e.ClienteId).IsRequired(false);

        }

    }
}
