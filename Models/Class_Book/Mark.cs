namespace library_db_book.Models.Class_Book
{
    public class Mark
    {
        public int Id { get; set; }
        public string TitleMark { get; set; }
        public IList<BookMarkRelation> Marks { get; set; }
    }
}