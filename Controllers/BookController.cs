using library_db_book.Models;
using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using library_db_book.Models.Dto.Book;

namespace library_db_book.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]s")]
	public class BookController : Controller
	{
		Context dbContext = new Context();
		private readonly ILogger<BookController> _logger;
		private readonly IMapper _mapper;
		public BookController(ILogger<BookController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
		public async Task<ActionResult<IList<BookOutDto>>> GetAllAsync()
		{
			var entities = await dbContext.Set<Book>().ToListAsync();
			var outDtos = _mapper.Map<List<BookOutDto>>(entities);
			return Ok(outDtos);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<BookOutDto>> GetByIdAsync([FromRoute] int id)
		{
			var entity = await dbContext.Set<Book>().SingleAsync(x => x.Id.Equals(id));
			var outDtos = _mapper.Map<BookOutDto>(entity);
			return Ok(outDtos);
		}
		[HttpPost("[action]")]
		[Consumes("application/json")]
		public async Task<ActionResult<BookOutDto>> CreateAsync([FromBody] CreateBookDto createDto)
		{
			var book = _mapper.Map<Book>(createDto);
			var entity = (await dbContext.Set<Book>().AddAsync(book)).Entity;
			await dbContext.SaveChangesAsync();
			var outDtos = _mapper.Map<BookOutDto>(entity);
			return Created(Request.Path, outDtos);
		}
		[HttpPut("[action]/{id}")]
		[Consumes("application/json")]
		public async Task<ActionResult<BookOutDto>> UpdateAsync(
				[FromRoute] int id,
				[FromBody] UpdateBookDto updateDto)
		{
			var book = _mapper.Map<Book>(updateDto);
			var entity = dbContext.Set<Book>().Update(book).Entity;
			await dbContext.SaveChangesAsync();
			var outDto = _mapper.Map<BookOutDto>(entity);
			return Ok(outDto);
		}
		[HttpDelete("[action]/{id}")]
		public async Task<ActionResult> RemoveAsync([FromRoute] int id)
		{
			var entity = await dbContext.Set<Book>().SingleAsync(x => x.Id.Equals(id));
			dbContext.Set<Book>().Remove(entity);
			await dbContext.SaveChangesAsync();
			return Ok();
		}
	}
}