using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure.Data;

namespace VocabularyBuilder.IntegrationTests.API.Base
{
    public static class  Utilities
    {
        public static void InitSeedDataFromTestDb(VocabularyBuilderDbContext dbContext)
        {
            dbContext.TypeCards.AddRange(new List<TypeCard>()
            {
                new TypeCard(){Description = "Daily"},
                new TypeCard(){Description = "Weekly"},
                new TypeCard(){Description = "Monthly"}
            });

            dbContext.Categories.AddRange(new List<Category>()
            {
                new Category(){Description = "Food"},
                new Category(){Description = "Animals"},
                new Category(){Description = "Education"},
                new Category(){Description = "Family"}
            });

            dbContext.FlashCards.AddRange(new List<FlashCard>()
            {
                new FlashCard(){TypeCardId = 1,CategoryId = 1,MainWord = "HeadSets",Example = "I Use headset all day",FlashCardDate = DateTime.UtcNow,Meaning = "Something useful with you ears",FlashCardPicture = new byte[]{1,2,3}},
                new FlashCard(){TypeCardId = 1,CategoryId = 1,MainWord = "Computer",Example = "My computer was downgraded",FlashCardDate = DateTime.UtcNow,Meaning = "Device important with a lot functionality",FlashCardPicture = new byte[]{1,2,3}},
                new FlashCard(){TypeCardId = 1,CategoryId = 1,MainWord = "Cellphone",Example = "I talk with someone by cellphone",FlashCardDate = DateTime.UtcNow,Meaning = "Device useful to talk an other functions",FlashCardPicture = new byte[]{1,2,3}},

            });

            dbContext.SaveChanges();
        }
    }
}
