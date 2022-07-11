using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class Mark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TitleMark { get; set; }
        public IList<BookMarkRelation> Marks { get; set; }
    }
}