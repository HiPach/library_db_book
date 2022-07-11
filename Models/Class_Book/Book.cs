using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Photo { get; set; }
        public string Category { get; set; }
        public string Mark { get; set; }
        public Reader Reader { get; set; }
        public Shelf Shelf { get; set; }
        public IList<BookMarkRelation> Marks { get; set; }
        public IList<BookCategoryRelation> Categories { get; set; }
    }
}

