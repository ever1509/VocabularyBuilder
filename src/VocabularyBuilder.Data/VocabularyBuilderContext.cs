using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VocabularyBuilder.Data.Configurations;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Data
{
    public class VocabularyBuilderContext:DbContext
    {
        public VocabularyBuilderContext(DbContextOptions<VocabularyBuilderContext> options)
        :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TypeCard> TypeCards { get; set; }
        public DbSet<FlashCard> FlashCards { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TypeCardConfiguration());
            modelBuilder.ApplyConfiguration(new FlashCardConfiguration());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());

        }
    }
}
