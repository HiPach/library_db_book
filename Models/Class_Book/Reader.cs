namespace library_db_book.Models.Class_Book
{
    public class Reader
    {
        public int Id { get; set; }
        public DateTime DateVisit { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BookList { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}