using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MySQLApp;
using Microsoft.EntityFrameworkCore;
using library_db_book.Models.Dto.Shelf;

namespace library_db_book.Controllers
{
    public class ShelfController : Controller
    {
        Context dbContext = new Context();
        private readonly ILogger<ShelfController> _logger;
        private readonly IMapper _mapper;
        public ShelfController(ILogger<ShelfController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        // --------------------------------------------------------GetByIdAsync-------------------------------------------------------------------------- //
        [HttpGet("{id}")]
        public async Task<ActionResult<ShelfOutDto>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Shelf>().SingleAsync(x => x.Id.Equals(id));
            var outDtos = _mapper.Map<List<ShelfOutDto>>(entity);
            return Ok(outDtos);
        }
        // --------------------------------------------------------GetAllAsync--------------------------------------------------------------------------- //
        [HttpGet]
        public async Task<ActionResult<IList<ShelfOutDto>>> GetAllAsync()
        {
            var entities = await dbContext.Set<Shelf>().ToListAsync();
            var outDtos = _mapper.Map<List<ShelfOutDto>>(entities);
            return Ok(outDtos);
        }
        // --------------------------------------------------------CreateAsync--------------------------------------------------------------------------- //
        [HttpPost("[action]")]
        [Consumes("application/json")]
        public async Task<ActionResult<ShelfOutDto>>CreateAsync([FromBody] CreateShelfDto createDto)
        {
            var shelf = _mapper.Map<Shelf>(createDto);
            var entity = (await dbContext.Set<Shelf>().AddAsync(shelf)).Entity;
            await dbContext.SaveChangesAsync();
            var outDtos = _mapper.Map<List<ShelfOutDto>>(entity);
            return Created(Request.Path, outDtos);
        }
        // --------------------------------------------------------UpdateAsync--------------------------------------------------------------------------- //
        [HttpPut("[action]/{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<ShelfOutDto>>UpdateAsync(
                [FromRoute] int id,
                [FromBody] UpdateShelfDto updateDto)
        {
            var shelf = _mapper.Map<Shelf>(updateDto);
            var entity = dbContext.Set<Shelf>().Update(shelf).Entity;
            await dbContext.SaveChangesAsync();
            var outDto = _mapper.Map<List<ShelfOutDto>>(entity);
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
