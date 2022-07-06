using library_db_book.Models;
using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AutoMapper;
using library_db_book.Controllers.Dto;
using MySQLApp;
using Microsoft.EntityFrameworkCore;

namespace library_db_book.Controllers
{
    public class BookController : Controller
    {


		private readonly ILogger<BookController> _logger;
       

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
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

		//TEntity - класс твоей сущности (пример, Book)
		//TOutDto - dto для вывода
		//TCreateDto - dto для создания новой записи
		// и т.п.
		

		private Context dbContext;
        private readonly IMapper _mapper;


        [HttpGet]
		public async Task<ActionResult<IList<OutBookDto>>> GetAllAsync()
		{
			var entities = await dbContext.Set<Book>().Select(x => !x.IsDeleted).ToListAsync();
			//мапишь ентити в outDto
			var outDtos = _mapper.Map<List<OutBookDto>>(entities);
			return Ok(outDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OutBookDto>> GetByIdAsync([FromRoute] int id)
		{
			var entity = await dbContext.Set<Book>().SingleAsync(x => x.Id.Equals(id));
			//мапишь ентити в outDto
			var outDtos = _mapper.Map<Book>(entity);
			return Ok(outDtos);
		}

		[HttpPost("[action]")]
		[Consumes("application/json")]
		public async Task<ActionResult<OutBookDto>> CreateAsync([FromBody] CreateBookDto createDto)
		{
			//мапишь createDto в TEntity (пример, CreateBookDto в Book)
			var createbookDto = _mapper.Map<Book>(createDto);
			var entity = (await dbContext.Set<Book>().AddAsync(createbookDto)).Entity;
			await dbContext.SaveChangesAsync();
			//мапишь ентити в outDto
			var outDtos = _mapper.Map<Book>(entity);
			return Created(Request.Path, outDtos);
		}

		[HttpPut("[action]/{id}")]
		[Consumes("application/json")]
		public async Task<ActionResult<OutBookDto>> UpdateAsync(
				[FromRoute] int id,
				[FromBody] UpdateBookDto updateDto
			)
		{
			//мапишь updateDto в TEntity (пример, UpdateBookDto в Book)
			var updatebookDto = _mapper.Map<Book>(updateDto);
			var entity = dbContext.Set<Book>().Update(updatebookDto).Entity;
			await dbContext.SaveChangesAsync();
			//также мапишь в outDto
			var outDto = _mapper.Map<Book>(entity);
			return Ok(outDto);
		}

		[HttpDelete("[action]/{id}")]
		public async Task<ActionResult> RemoveAsync([FromRoute] int id)
		{
			var entity = await dbContext.Set<Book>().SingleAsync(x => x.Id.Equals(id));//или Remove, точно не помню;
			var outDto = dbContext.Set<Book>().Remove(entity).Entity;
		return Ok();
		}
	}
}