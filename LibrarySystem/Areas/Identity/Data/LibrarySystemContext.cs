using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{
    public class LibrarySystemContext : IdentityDbContext<IdentityUser>
    {
        // DbSet for the Book entity
        public DbSet<Book> Books { get; set; }

        public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.

            // Add your customizations after calling base.OnModelCreating(builder);

            // Configure the Book entity
            builder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(50);
                entity.Property(b => b.Author).IsRequired().HasMaxLength(50);
                entity.Property(b => b.PublicationYear).HasColumnType("int");
                entity.Property(b => b.Description).HasMaxLength(50);
                // Add other configurations for the Book entity

                // You can also configure relationships, indexes, etc.
            });
        }
    }
}
