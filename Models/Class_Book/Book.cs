namespace library_db_book.Models.Class_Book
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Photo { get; set; }
        public string Reader { get; set; }
        public string Category { get; set; }
        public string Mark { get; set; }
        public string Shelf { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}

