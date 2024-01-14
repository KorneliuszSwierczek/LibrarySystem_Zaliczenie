using LibrarySystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Data
{
    public class LibrarySystemContext : IdentityDbContext<IdentityUser>
    {
        
        public DbSet<Book> Books { get; set; }

        public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure the Book entity
            builder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(50);
                entity.Property(b => b.Author).IsRequired().HasMaxLength(50);
                entity.Property(b => b.PublicationYear).HasColumnType("int");
                entity.Property(b => b.Description).HasMaxLength(50);
                entity.Property(b => b.Categories).HasMaxLength(50);
                

                
            });

            // Seed the database with sample data
            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            // Add sample books
            var books = new List<Book>
            {
                new Book
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            Description = "A novel about the American Dream",
            Categories = "Fiction, Classic"
        },
        new Book
        {
            Id = 2,
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            PublicationYear = 1960,
            Description = "A classic of modern American literature",
            Categories = "Fiction, Classic"
        },
        new Book
        {
            Id = 3,
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            PublicationYear = 1937,
            Description = "A fantasy classic",
            Categories = "Fantasy, Adventure"
        }
            };

            builder.Entity<Book>().HasData(books.Select(b => new
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                PublicationYear = b.PublicationYear,
                Description = b.Description,
                Categories = string.Join(",", b.Categories)
            }));
        }
    }
}
