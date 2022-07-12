using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class Reader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int Id { get; set; }
        virtual public DateTime DateVisit { get; set; }
        virtual public string FirstName { get; set; }
        virtual public string MiddleName { get; set; }
        virtual public string LastName { get; set; }
        virtual public IList<Book> Books { get; set; }
        virtual public DateTime DateRegistration { get; set; }
    }
}