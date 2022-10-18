
using LojaOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaOnline.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //A Entidade PromocaoProduto tem como chave a (Composição) das duas propriedades definidas abaixo.
            //Chave primária composta, para relacionamento (N:N)
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });


            //Definições para relacionamento (1:1)
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=localhost;Initial Catalog=LojaOnlineDb;User Id=sa;Password=31457831; Integrated Security=True");
        }
    }
}
