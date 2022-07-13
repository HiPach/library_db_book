using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    [Table("Mark")]
    public class Mark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<BookMarkRelation> BookMark { get; set; }
    }
}