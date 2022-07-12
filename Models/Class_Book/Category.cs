using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int Id { get; set; }
        virtual public string Name { get; set; }
        virtual public IList<BookCategoryRelation> BookCategory { get; set; }
    }
}