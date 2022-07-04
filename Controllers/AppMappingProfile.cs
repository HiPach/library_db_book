using AutoMapper;
using library_db_book.Models.Class_Book;

namespace library_db_book.Controllers
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			CreateMap<CreateBookDto, Book>().ReverseMap();
			CreateMap<UpdateBookDto, Book>().ReverseMap();
			CreateMap<OutBookDto, Book>().ReverseMap();
		}
	}
}
