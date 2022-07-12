using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    [Table("Book")]
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int Id { get; set; }
        virtual public string Author { get; set; }
        virtual public string Photo { get; set; }
        virtual public Reader Reader { get; set; }
        virtual public Shelf Shelf { get; set; }
        virtual public IList<BookMarkRelation> BookMark { get; set; }
        virtual public IList<BookCategoryRelation> BookCategory { get; set; }
    }
}

