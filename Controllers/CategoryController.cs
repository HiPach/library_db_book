using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using library_db_book.Models.Dto.Category;

namespace library_db_book.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class CategoryController : Controller
    {
        Context dbContext = new Context();
        private readonly ILogger<CategoryController> _logger;
        private readonly IMapper _mapper;
        public CategoryController(ILogger<CategoryController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        // --------------------------------------------------------GetByIdAsync-------------------------------------------------------------------------- //
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryOutDto>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Category>().SingleAsync(x => x.Id.Equals(id));
            var outDtos = _mapper.Map<CategoryOutDto>(entity);
            return Ok(outDtos);
        }
        // --------------------------------------------------------GetAllAsync--------------------------------------------------------------------------- //
        [HttpGet]
        public async Task<ActionResult<IList<CategoryOutDto>>> GetAllAsync()
        {
            var entities = await dbContext.Set<Category>().ToListAsync();
            var outDtos = _mapper.Map<List<CategoryOutDto>>(entities);
            return Ok(outDtos);
        }
        // --------------------------------------------------------CreateAsync--------------------------------------------------------------------------- //
        [HttpPost("[action]")]
        [Consumes("application/json")]
        public async Task<ActionResult<CategoryOutDto>>CreateAsync([FromBody] CreateCategoryDto createDto)
        {
            var category = _mapper.Map<Category>(createDto);
            var entity = (await dbContext.Set<Category>().AddAsync(category)).Entity;
            await dbContext.SaveChangesAsync();
            var outDtos = _mapper.Map<CategoryOutDto>(entity);
            return Created(Request.Path, outDtos);
        }
        // --------------------------------------------------------UpdateAsync--------------------------------------------------------------------------- //
        [HttpPut("[action]/{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<CategoryOutDto>>UpdateAsync(
                [FromRoute] int id,
                [FromBody] UpdateCategoryDto updateDto)
        {
            var category = _mapper.Map<Category>(updateDto);
            var entity = dbContext.Set<Category>().Update(category).Entity;
            await dbContext.SaveChangesAsync();
            var outDto = _mapper.Map<CategoryOutDto>(entity);
            return Ok(outDto);
        }
        // --------------------------------------------------------RemoveAsync----------------------------------------------------------------------------//
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> RemoveAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Shelf>().SingleAsync(x => x.Id.Equals(id));
            dbContext.Set<Shelf>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
