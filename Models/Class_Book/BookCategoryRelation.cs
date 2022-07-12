using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    [Table("Book_Category_Relation")]
    public class BookCategoryRelation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual int BookId { get; set; }
        public virtual int CategoryId { get; set; }
    }
}