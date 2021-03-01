using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevIO.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            //Para evitar delete cascade.
            foreach (var relationship in modelBuilder.Model
                                                     .GetEntityTypes()
                                                     .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            foreach (var property in modelBuilder.Model
                                                 .GetEntityTypes()
                                                 .SelectMany(e => e.GetProperties()
                                                 .Where(p => p.ClrType == typeof(string))))
            {
                property.Relational().ColumnType = "varchar(100)";
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
