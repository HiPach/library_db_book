using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class Shelf
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}