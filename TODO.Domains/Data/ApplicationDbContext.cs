using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace TODO.Domains.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            CheckCreated();
        }

        private void CheckCreated()
        {
            if (!Categories.Any())
            {

                Categories.Add(new Category
                {
                    Id = 1,
                    Name = "Home"
                });

                Categories.Add(new Category
                {
                    Id = 2,
                    Name = "Work"
                });

                Categories.Add(new Category
                {
                    Id = 3,
                    Name = "Hobby"
                });

                SaveChanges();
            }
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

        }
    }
}
