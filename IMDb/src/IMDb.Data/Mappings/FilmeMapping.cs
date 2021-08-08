using IMDb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDb.Data.Mappings
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(255)");
            builder.Property(c => c.Diretor).IsRequired().HasColumnType("varchar(255)");
            builder.Property(c => c.Genero).IsRequired().HasColumnType("varchar(100)");
        }
    }
}
