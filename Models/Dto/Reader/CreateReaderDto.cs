namespace library_db_book.Models.Dto.Reader
{ 
    public class CreateReaderDto
    {
        public DateTime DateVisit { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}