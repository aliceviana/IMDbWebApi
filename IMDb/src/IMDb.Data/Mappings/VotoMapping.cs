using IMDb.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMDb.Data.Mappings
{
    public class VotoMapping : IEntityTypeConfiguration<Voto>
    {
        public void Configure(EntityTypeBuilder<Voto> builder)
        {
            builder.ToTable("Voto");

            builder.HasKey(p => p.Id);
            builder.Property(c => c.Nota).IsRequired();
        }
    }
}
