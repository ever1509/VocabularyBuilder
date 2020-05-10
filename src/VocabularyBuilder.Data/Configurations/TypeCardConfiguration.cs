using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Data.Configurations
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
