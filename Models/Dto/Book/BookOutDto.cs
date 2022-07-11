using library_db_book.Models.Dto.Reader;
using library_db_book.Models.Dto.Shelf;

namespace library_db_book.Models.Dto.Book
{
    public class BookOutDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ShelfOutDto Shelf { get; set; }
        public ReaderOutDto Reader { get; set; }
        public IList<CategoryOutDto> Categories { get; set; }
        public IList<MarkOutDto> Marks { get; set; }
    }
}
