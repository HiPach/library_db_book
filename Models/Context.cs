using library_db_book.Models.Class_Book;
using Microsoft.EntityFrameworkCore;

namespace library_db_book
{
    public class Context : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCategoryRelation> BookCategoryRelation { get; set; }
        public DbSet<BookMarkRelation> BookMarkRelation { get; set; }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Shelf> Shelf { get; set; }
        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=HiPachSQL;password=oKh9FrO8Tp;database=library_db;",
                new MySqlServerVersion(new Version(8, 0, 29))
            );
        }
	}
}
