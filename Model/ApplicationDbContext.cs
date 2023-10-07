using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            //Empty constructor, needed for Dependency Injection
        }

        public DbSet<Book> Book { get; set; } //Adding the Book Model to the database
    }
}
