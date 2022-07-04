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
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
       

        public HomeController(ILogger<HomeController> logger)
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
        private object outDtos;

        [HttpGet]
		public async Task<ActionResult<IList<OutBookDto>>> GetAllAsync()
		{
			var entities = await dbContext.Set<Book>().Where(x => !x.IsDeleted).ToListAsync();
			//мапишь ентити в outDto
			var book = _mapper.Map<Book>(outDtos);
			outDtos = book; //mapping
			return Ok(outDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<OutBookDto>> GetByIdAsync([FromRoute] TId id)
		{
			var entity = await dbContext.Set<Book>().Single(x => x.Id.Equals(id));
			//мапишь ентити в outDto
			var book = _mapper.Map<Book>(outDtos);
			outDtos = book; //mapping
			return Ok(outDtos);
		}

		[HttpPost("[action]")]
		[Consumes("application/json")]
		public async Task<ActionResult<OutBookDto>> CreateAsync([FromBody] TCreateDto createDto)
		{
			//мапишь createDto в TEntity (пример, CreateBookDto в Book)
			var createDto = _mapper.Map<CreateBookDto>(Book);
			var entity = (await DbContext.Set<Book>().AddAsync(obj)).Entity;
			await DbContext.SaveChangesAsync();
			//мапишь ентити в outDto
			var Book = _mapper.Map<Book>(outDtos);
			outDtos = Book; //mapping
			return Created(Request.Path, outDtos);
		}

		[HttpPut("[action]/{id}")]
		[Consumes("application/json")]
		public async Task<ActionResult<TOutDto>> UpdateAsync(
				[FromRoute] TId id,
				[FromBody] TUpdateDto updateDto
			)
		{
			//мапишь updateDto в TEntity (пример, UpdateBookDto в Book)
			var updateDto = _mapper.Map<UpdateBookDto>(Book);
			var outDto = dbContext.Set<Book>().Update(obj).Entity;
			await dbContext.SaveChangesAsync();
			//также мапишь в outDto
			var Book = _mapper.Map<Book>(OutBookDto);
			outDto = updateDto; //mapping
			return Ok(outDto);
		}

		[HttpDelete("[action]/{id}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] TId id)
		{
			await dbContext.Set<Book>().Delete(id); //или Remove, точно не помню;
		return Ok();
		}
	}
}