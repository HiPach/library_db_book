﻿using library_db_book.Models.Class_Book;

namespace library_db_book.Models.Dto
{
    public class CreateBookDto
    {
        public string Author { get; set; }
        public string Photo { get; set; }
        public int ReaderId { get; set; }
        public int[] CategoryIds { get; set; }
        public int[] MarkIds { get; set; }
        public string Shelf { get; set; }

    }
}