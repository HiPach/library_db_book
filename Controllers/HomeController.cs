using library_db_book.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

		[HttpGet]
		public async Task<ActionResult<IList<TOutDtos>>> GetAllAsync()
		{
			var entities = await dbContext.Set<Book>().Where(x => !x.IsDeleted).ToListAsync();
			//мапишь ентити в outDto
			var Book = _mapper.Map<Book>(TOutDto);
			outDtos = Book; //mapping
			return Ok(outDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TOutDto>> GetByIdAsync([FromRoute] TId id)
		{
			var entity = await dbContext.Set<Book>().Single(x => x.Id.Equals(id));
			//мапишь ентити в outDto
			var Book = _mapper.Map<Book>(outDto);
			outDto = Book; //mapping
			return Ok(outDto);
		}

		[HttpPost("[action]")]
		[Consumes("application/json")]
		public async Task<ActionResult<TOutDto>> CreateAsync([FromBody] TCreateDto createDto)
		{
			//мапишь createDto в TEntity (пример, CreateBookDto в Book)
			var createDto = _mapper.Map<createDto>(Book);
			var entity = (await dbContext.Set<Book>().AddAsync(obj)).Entity;
			await dbContext.SaveChangesAsync();
			//мапишь ентити в outDto
			var Book = _mapper.Map<Book>(TOutDto);
			outDto = Book; //mapping
			return Created(Request.Path, outDto);
		}

		[HttpPut("[action]/{id}")]
		[Consumes("application/json")]
		public async Task<ActionResult<TOutDto>> UpdateAsync(
				[FromRoute] TId id,
				[FromBody] TUpdateDto updateDto
			)
		{
			//мапишь updateDto в TEntity (пример, UpdateBookDto в Book)
			var updateDto = _mapper.Map<updateDto>(Book);
			var outDto = dbContext.Set<Book>().Update(obj).Entity;
			await dbContext.SaveChangesAsync();
			//также мапишь в outDto
			var Book = _mapper.Map<Book>(TOutDto);
			outDto = updateDto; //mapping
			return Ok(outDto);
		}

		[HttpDelete("[action]/{id}")]
		public async Task<ActionResult> DeleteAsync([FromRoute] TId id)
		{
			await dbContext.Set<Book>().Delete(id)//или Remove, точно не помню;
		return Ok();
		}
	}
}