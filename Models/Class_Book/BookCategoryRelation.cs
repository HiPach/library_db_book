﻿using System.ComponentModel.DataAnnotations.Schema;

namespace library_db_book.Models.Class_Book
{
    public class BookCategoryRelation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        virtual public int Id { get; set; }
        virtual public int BookId { get; set; }
        virtual public int CategoryId { get; set; }
    }
}