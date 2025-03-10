using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected DataContext()
        {
        }
        public DbSet<Page> Pages{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Page>().HasData(
                new Page { Id = 1, Title = "Home",Slug="home",Body ="this is the home page" },
                new Page { Id = 2, Title = "About",Slug="about",Body = "this is the about page" },
                new Page { Id = 3, Title = "Services",Slug="services",Body = "this is the services page" },
                new Page { Id = 4, Title = "Contact",Slug="contact",Body = "this is the contact page" }
                );
        }
    }
    
}
