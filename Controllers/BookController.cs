using library_db_book.Models;
using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using MySQLApp;
using Microsoft.EntityFrameworkCore;
using library_db_book.Models.Dto.Book;

namespace library_db_book.Controllers
{
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
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
		public async Task<ActionResult<IList<BookOutDto>>> GetAllAsync()
		{
			var entities = await dbContext.Set<Book>().ToListAsync();// Select()
			var outDtos = _mapper.Map<List<BookOutDto>>(entities);
			return Ok(outDtos);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<BookOutDto>> GetByIdAsync([FromRoute] int id)
		{
			var entity = await dbContext.Set<Book>().SingleAsync(x => x.Id.Equals(id));
			var outDtos = _mapper.Map<Book>(entity);
			return Ok(outDtos);
		}
		[HttpPost("[action]")]
		[Consumes("application/json")]
		public async Task<ActionResult<BookOutDto>> CreateAsync([FromBody] CreateBookDto createDto)
		{
			var createbookDto = _mapper.Map<Book>(createDto);
			var entity = (await dbContext.Set<Book>().AddAsync(createbookDto)).Entity;
			await dbContext.SaveChangesAsync();
			var outDtos = _mapper.Map<Book>(entity);
			return Created(Request.Path, outDtos);
		}
		[HttpPut("[action]/{id}")]
		[Consumes("application/json")]
		public async Task<ActionResult<BookOutDto>> UpdateAsync(
				[FromRoute] int id,
				[FromBody] UpdateBookDto updateDto)
		{
			var updatebookDto = _mapper.Map<Book>(updateDto);
			var entity = dbContext.Set<Book>().Update(updatebookDto).Entity;
			await dbContext.SaveChangesAsync();
			var outDto = _mapper.Map<Book>(entity);
			return Ok(outDto);
		}
		[HttpDelete("[action]/{id}")]
		public async Task<ActionResult> RemoveAsync([FromRoute] int id)
		{
			var entity = await dbContext.Set<Book>().SingleAsync(x => x.Id.Equals(id));
			var outDto = dbContext.Set<Book>().Remove(entity).Entity;
		return Ok();
		}
	}
}