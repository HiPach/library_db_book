namespace library_db_book.Models.Class_Book
{
    public class Shelf
    {
        public int Id { get; set; }
        public string NumberShelf { get; set; }
        public IList<Book> Shelfs { get; set; }
    }
}