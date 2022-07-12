using AutoMapper;
using library_db_book.Models.Class_Book;
using library_db_book.Models.Dto.Book;

namespace library_db_book.Controllers.Map
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateShelfDto, Book>().ReverseMap();
            CreateMap<UpdateShelfDto, Book>().ReverseMap();
            CreateMap<BookOutDto, Book>().ReverseMap();
        }
    }
}
