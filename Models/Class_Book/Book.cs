using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    [Table("Library_db")]
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Photo { get; set; }
        public Reader Reader { get; set; }
        public Shelf Shelf { get; set; }
        public IList<BookMarkRelation> BookMark { get; set; }
        public IList<BookCategoryRelation> BookCategory { get; set; }
    }
}

