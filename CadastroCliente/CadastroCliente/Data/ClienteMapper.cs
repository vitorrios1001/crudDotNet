using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroCliente.Data
{
    public class ClienteMapper : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Endereco)
                .HasMaxLength(60);

            builder.Property(c => c.Bairro)
                .HasMaxLength(50);        

            builder.Property(c => c.Status)
                .HasDefaultValue(true);                
        
            builder.Property(c => c.Uf)
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.Cidade)
                .HasMaxLength(150)
                .IsRequired();

            builder.ToTable("Cliente");  
        
        }

    }
}