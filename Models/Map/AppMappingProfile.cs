using AutoMapper;
using library_db_book.Models.Class_Book;
using library_db_book.Models.Dto.Book;
using library_db_book.Models.Dto.Shelf;
using library_db_book.Models.Dto.Category;
using library_db_book.Models.Dto.Mark;
using library_db_book.Models.Dto.Reader;

namespace library_db_book.Controllers.Map
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();
            CreateMap<BookOutDto, Book>().ReverseMap();

            CreateMap<CreateShelfDto, Shelf>().ReverseMap();
            CreateMap<UpdateShelfDto, Shelf>().ReverseMap();
            CreateMap<ShelfOutDto, Shelf>().ReverseMap();

            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryOutDto, Category>().ReverseMap();

            CreateMap<CreateMarkDto, Mark>().ReverseMap();
            CreateMap<UpdateMarkDto, Mark>().ReverseMap();
            CreateMap<MarkOutDto, Mark>().ReverseMap();

            CreateMap<CreateReaderDto, Reader>().ReverseMap();
            CreateMap<UpdateReaderDto, Reader>().ReverseMap();
            CreateMap<ReaderOutDto, Reader>().ReverseMap();
        }
    }
}
