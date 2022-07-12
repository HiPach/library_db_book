namespace library_db_book.Models.Dto.Mark
{ 
    public class CreateMarkDto
    {
        public string Name { get; set; }
        public IList<MarkOutDto> Marks { get; set; }

    }
}