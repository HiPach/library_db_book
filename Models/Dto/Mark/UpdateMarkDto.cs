namespace library_db_book.Models.Dto.Mark
{
    public class UpdateMarkDto
    {
        public string Author { get; set; }
        public string Photo { get; set; }
        public int ReaderId { get; set; }
        public int[] CategoryIds { get; set; }
        public int[] MarkIds { get; set; }
        public int ShelfId { get; set; }
    }
}