using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class Mark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int Id { get; set; }
        virtual public string Name { get; set; }
        virtual public IList<BookMarkRelation> BookMark { get; set; }
    }
}