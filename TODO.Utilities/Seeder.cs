using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using TODO.Domains;
using TODO.Domains.Data;

namespace TODO.Utilities
{
    public static class Seeder
    {
        public static void SeedCategories(ApplicationDbContext dbContext)
        {
            if (!dbContext.Categories.Any())
            {

                dbContext.Categories.Add(new Category
                {
                    Id = 1,
                    Name = "Home"
                });

                dbContext.Categories.Add(new Category
                {
                    Id = 2,
                    Name = "Work"
                });

                dbContext.Categories.Add(new Category
                {
                    Id = 3,
                    Name = "Hobby"
                });

                dbContext.SaveChanges();
            }
        }
    }
}
