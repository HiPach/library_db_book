using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    [Table("Book_Mark_Relation")]
    public class BookMarkRelation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int Id { get; set; }
        public virtual int BookId { get; set; }
        public virtual int MarkId { get; set; }
    }
}