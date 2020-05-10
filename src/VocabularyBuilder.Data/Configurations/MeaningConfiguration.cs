using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Data.Configurations
{
    public class MeaningConfiguration:IEntityTypeConfiguration<Meaning>
    {
        public void Configure(EntityTypeBuilder<Meaning> builder)
        {
            builder.HasKey(e => e.MeaningId);
            builder.Property(e => e.Description).HasColumnType("varchar(100)");


        }
    }
}
