
using library_db_book.Models.Class_Book;

namespace library_db_book.Controllers.Dto
{
    public class CreateBookDto
    {
        public string Author { get; set; }
        public string Photo { get; set; }
        public string Reader { get; set; }
        public string Category { get; set; }
        public string Mark { get; set; }
        public string Shelf { get; set; }

    }
}