namespace library_db_book.Models.Dto.Category
{
    public class CategoryOutDto
    {
        public string Name { get; set; }
        public IList<CategoryOutDto> Categories { get; set; }
    }
}