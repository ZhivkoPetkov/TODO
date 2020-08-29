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

                dbContext.Tasks.Add(new Task
                {
                    Id = 1,
                    Title = "Shut down oven",
                    CategoryId = 1,
                    IsImportant = true,
                    IsFinished = true,
                    CreatedOn = DateTime.UtcNow.Date.AddDays(-2),
                    EndDate = DateTime.UtcNow.Date.AddDays(-1)
                });

                dbContext.Tasks.Add(new Task
                {
                    Id = 2,
                    Title = "Backup on machine FLK1",
                    CategoryId = 2,
                    IsImportant = true,
                    IsFinished = false,
                    CreatedOn = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date
                });

                dbContext.Tasks.Add(new Task
                {
                    Id = 3,
                    Title = "Fishing rod for repair",
                    CategoryId = 3,
                    IsImportant = false,
                    IsFinished = false,
                    CreatedOn = DateTime.UtcNow.Date,
                    EndDate = DateTime.UtcNow.Date.AddDays(4)
                });

                dbContext.Tasks.Add(new Task
                {
                    Id = 4,
                    Title = "Bet on Bet365 for World Cup winner",
                    CategoryId = 3,
                    IsImportant = true,
                    IsFinished = false,
                    CreatedOn = DateTime.UtcNow.Date.AddDays(-10),
                    EndDate = DateTime.UtcNow.Date.AddDays(-3)
                });

                dbContext.SaveChanges();
            }
        }
    }
}
