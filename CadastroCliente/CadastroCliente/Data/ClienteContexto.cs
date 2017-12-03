using System;
using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Data
{
    public class ClienteContexto : DbContext
    {

        public ClienteContexto(DbContextOptions<ClienteContexto> options) : base(options)
        {
        }
        
        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>().ToTable("Cliente");
        }
        
    }
}