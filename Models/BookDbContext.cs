using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Dodaj dowolne konfiguracje dodatkowe modelu, jeśli są wymagane
        }
    }
}
