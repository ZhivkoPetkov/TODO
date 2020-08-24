using Microsoft.EntityFrameworkCore;

namespace TODO.Domains.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
            this.Categories.Add(new Category
            {
                Id = 1,
                Name = "Home"
            });

            this.Categories.Add(new Category
            {
                Id = 2,
                Name = "Work"
            });

            this.Categories.Add(new Category
            {
                Id = 3,
                Name = "Hobby"
            });

            SaveChanges();
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
