namespace library_db_book.Models.Class_Book
{
    public class BookCategoryRelation
    {
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public int Category_Id { get; set; }
    }
}