using AutoMapper;
using library_db_book.Models.Class_Book;
using library_db_book.Models.Dto.BookOutDto;
using library_db_book.Models.Dto.CreateOutDto;
using library_db_book.Models.Dto.UpdateOutDto;

namespace library_db_book.Controllers.Map
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();
            CreateMap<BookOutDto, Book>().ReverseMap();
        }
    }
}
