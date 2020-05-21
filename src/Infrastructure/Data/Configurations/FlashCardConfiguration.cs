using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class FlashCardConfiguration:IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.HasKey(e => e.FlashCardId);
            builder.Property(e => e.MainWord).HasColumnType("varchar(50)");
            builder.Property(e => e.Example).HasColumnType("varchar(1000)").IsRequired(false);
            builder.Property(e => e.FlashCardDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.FlashCardPicture).IsRequired(false);
            builder.Property(e => e.Meaning).HasMaxLength(100);

            builder.HasOne(e => e.Category)
                .WithMany(d => d.FlashCards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("FK_FlashCard_Category");

            builder.HasOne(e => e.TypeCard)
                .WithMany(d => d.FlashCards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(e => e.TypeCardId)
                .HasConstraintName("FK_FlashCard_TypeCard");

        }
    }
}
