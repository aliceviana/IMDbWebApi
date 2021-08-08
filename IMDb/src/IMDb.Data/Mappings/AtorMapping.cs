using IMDb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDb.Data.Mappings
{
    public class AtorMapping : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder.ToTable("Ator");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Nome).IsRequired().HasColumnType("varchar(255)");
        }
    }
}
