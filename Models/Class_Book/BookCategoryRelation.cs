using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class BookCategoryRelation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookId { get; set; }
        public IList<Category> CategoryId { get; set; }
    }
}