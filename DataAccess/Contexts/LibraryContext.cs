using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class LibraryContext :DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<BookWriter> BookWriters { get; set; }

        public LibraryContext(DbContextOptions options) : base(options) 
        {
            
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BookWriter>().HasKey(ps => new { ps.BookId, ps.WriterId }); // iki özellik kullanacaksak süslü parantez içine kullanılmalı.
		}
	}
}
