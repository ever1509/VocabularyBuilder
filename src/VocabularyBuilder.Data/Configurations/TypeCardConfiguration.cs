using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
