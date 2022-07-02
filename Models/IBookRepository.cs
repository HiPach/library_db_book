using library_db_book.Models.Class_Book;

namespace library_db_book.Models
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        Book Add(Book item);
        void Remove(int id);
        bool Update(Book item);
    }
}
