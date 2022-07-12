using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    [Table("Book")]
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Author { get; set; }
        public virtual string Photo { get; set; }
        public virtual int ReaderId { get; set; }
        public virtual int ShelfId { get; set; }
        public virtual Reader Reader { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual IList<BookMarkRelation> BookMark { get; set; }
        public virtual IList<BookCategoryRelation> BookCategory { get; set; }
        public virtual string Name { get; set; }
    }
}

