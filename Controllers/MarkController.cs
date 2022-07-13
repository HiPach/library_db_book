using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using library_db_book.Models.Dto.Mark;

namespace library_db_book.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class MarkController : Controller
    {
        Context dbContext = new Context();
        private readonly ILogger<MarkController> _logger;
        private readonly IMapper _mapper;
        public MarkController(ILogger<MarkController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        // --------------------------------------------------------GetByIdAsync-------------------------------------------------------------------------- //
        [HttpGet("{id}")]
        public async Task<ActionResult<MarkOutDto>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Mark>().SingleAsync(x => x.Id.Equals(id));
            var outDtos = _mapper.Map<MarkOutDto>(entity);
            return Ok(outDtos);
        }
        // --------------------------------------------------------GetAllAsync--------------------------------------------------------------------------- //
        [HttpGet]
        public async Task<ActionResult<IList<MarkOutDto>>> GetAllAsync()
        {
            var entities = await dbContext.Set<Mark>().ToListAsync();
            var outDtos = _mapper.Map<List<MarkOutDto>>(entities);
            return Ok(outDtos);
        }
        // --------------------------------------------------------CreateAsync--------------------------------------------------------------------------- //
        [HttpPost("[action]")]
        [Consumes("application/json")]
        public async Task<ActionResult<MarkOutDto>>CreateAsync([FromBody] CreateMarkDto createDto)
        {
            var mark = _mapper.Map<Mark>(createDto);
            var entity = (await dbContext.Set<Mark>().AddAsync(mark)).Entity;
            await dbContext.SaveChangesAsync();
            var outDtos = _mapper.Map<MarkOutDto>(entity);
            return Created(Request.Path, outDtos);
        }
        // --------------------------------------------------------UpdateAsync--------------------------------------------------------------------------- //
        [HttpPut("[action]/{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<MarkOutDto>>UpdateAsync(
                [FromRoute] int id,
                [FromBody] UpdateMarkDto updateDto)
        {
            var mark = _mapper.Map<Mark>(updateDto);
            var entity = dbContext.Set<Mark>().Update(mark).Entity;
            await dbContext.SaveChangesAsync();
            var outDto = _mapper.Map<MarkOutDto>(entity);
            return Ok(outDto);
        }
        // --------------------------------------------------------RemoveAsync----------------------------------------------------------------------------//
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> RemoveAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Mark>().SingleAsync(x => x.Id.Equals(id));
            dbContext.Set<Mark>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
