using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.Property(x => x.FirstName).HasMaxLength(255);
                builder.Property(x => x.LastName).HasMaxLength(255);
            }
        }

        private class BookEntityConfiguration : IEntityTypeConfiguration<Book>
        {
            public void Configure(EntityTypeBuilder<Book> builder)
            {
                builder.HasKey(b => b.Id);
                builder.Property(b => b.Title).IsRequired().HasMaxLength(50);
                builder.Property(b => b.Author).IsRequired().HasMaxLength(50);
                builder.Property(b => b.PublicationYear).HasColumnType("int");
                builder.Property(b => b.Description).HasMaxLength(50);
                // Add other configurations for the Book entity

                // You can also configure relationships, indexes, etc.
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            // Add other configurations

            base.OnModelCreating(modelBuilder);
        }
    }
}
