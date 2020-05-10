using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;

namespace VocabularyBuilder.Data
{
    public class VocabularyBuilderContextFactory: IDesignTimeDbContextFactory<VocabularyBuilderContext>
    {
        public VocabularyBuilderContext CreateDbContext(string[] args)
        {
            var optionsBuilder= new DbContextOptionsBuilder<VocabularyBuilderContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Database=VocabularyBuilderDb;");
            return new VocabularyBuilderContext(optionsBuilder.Options);
        }
    }
}
