namespace library_db_book.Models.Class_Book
{
    public class Reader
    {
        public int Id { get; set; }
        public DateTime Date_Visit { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_Registration { get; set; }
    }
}