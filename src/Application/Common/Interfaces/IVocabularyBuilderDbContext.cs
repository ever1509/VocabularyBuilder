using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IVocabularyBuilderDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<TypeCard> TypeCards { get; set; }
        DbSet<FlashCard> FlashCards { get; set; }
        DbSet<RefreshToken> RefreshTokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
