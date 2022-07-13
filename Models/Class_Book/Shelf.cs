using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    [Table("Shelf")]
    public class Shelf
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Book> Books { get; set; }
    }
}