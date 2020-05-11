using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Data.Configurations
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

            builder.HasOne(e => e.Meaning)
                .WithOne(d => d.FlashCard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey<FlashCard>(e=>e.MeaningId)
                .HasConstraintName("FK_FlashCard_Meaning");
        }
    }
}
