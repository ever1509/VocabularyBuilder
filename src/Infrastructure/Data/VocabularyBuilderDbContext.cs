using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class VocabularyBuilderDbContext:IdentityDbContext<ApplicationUser>,IVocabularyBuilderDbContext
    {
        public VocabularyBuilderDbContext(DbContextOptions<VocabularyBuilderDbContext> options)
        :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TypeCard> TypeCards { get; set; }
        public DbSet<FlashCard> FlashCards { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
