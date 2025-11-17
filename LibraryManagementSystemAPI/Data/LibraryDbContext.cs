using LibraryManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Book>()
                .Property(b => b.ISBN)
                .HasMaxLength(20); 

            
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Kolawole",
                    LastName = "Opeyemi",
                    Bio = "Nigerian novelist, poet, professor, and critic.",
                    DateOfBirth = new DateTime(1990, 7, 14),
                    CreatedOn = DateTime.Now,
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    Id = Guid.NewGuid(),
                    Name = "Classic Literature",
                    Description = "Timeless works of literary art.",
                    CreatedOn = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}
