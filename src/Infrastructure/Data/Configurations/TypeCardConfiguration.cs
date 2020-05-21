using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TypeCardConfiguration:IEntityTypeConfiguration<TypeCard>
    {
        public void Configure(EntityTypeBuilder<TypeCard> builder)
        {
            builder.HasKey(e => e.TypeCardId);
            builder.Property(e => e.Description).HasColumnType("varchar(100)");

        }
    }
}
