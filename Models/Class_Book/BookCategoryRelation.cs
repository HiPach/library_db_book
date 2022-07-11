namespace library_db_book.Models.Class_Book
{
    public class BookCategoryRelation
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryList { get; set; }
    }
}