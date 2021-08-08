using IMDb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDb.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(255)");
            builder.Property(c => c.Email).IsRequired().HasColumnType("varchar(255)");
            builder.Property(c => c.Role).IsRequired().HasColumnType("varchar(255)");
        }
    }
}
