namespace library_db_book.Models.Class_Book
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<BookCategoryRelation> Categories { get; set; }
    }
}