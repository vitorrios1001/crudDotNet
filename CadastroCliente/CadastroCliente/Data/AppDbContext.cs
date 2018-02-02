using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public DbSet<ClienteModel> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapper());

            base.OnModelCreating(modelBuilder);
        }

        public static string ConnectionString{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString);
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}