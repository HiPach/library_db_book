using library_db_book.Models.Class_Book;
using Microsoft.EntityFrameworkCore;

namespace MySQLApp
{
    public class Context : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCategoryRelation> BookCategoryRelation { get; set; }
        public DbSet<BookMarkRelation> BookMarkRelation { get; set; }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Shelf> Shelf { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=HiPachSQL;password=oKh9FrO8Tp;database=library_db;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
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
