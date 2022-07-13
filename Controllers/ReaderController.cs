using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using library_db_book.Models.Dto.Reader;

namespace library_db_book.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]s")]
    public class ReaderController : Controller
    {
        Context dbContext = new Context();
        private readonly ILogger<ReaderController> _logger;
        private readonly IMapper _mapper;
        public ReaderController(ILogger<ReaderController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        // --------------------------------------------------------GetByIdAsync-------------------------------------------------------------------------- //
        [HttpGet("{id}")]
        public async Task<ActionResult<ReaderOutDto>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Reader>().SingleAsync(x => x.Id.Equals(id));
            var outDtos = _mapper.Map<ReaderOutDto>(entity);
            return Ok(outDtos);
        }
        // --------------------------------------------------------GetAllAsync--------------------------------------------------------------------------- //
        [HttpGet]
        public async Task<ActionResult<IList<ReaderOutDto>>> GetAllAsync()
        {
            var entities = await dbContext.Set<Reader>().ToListAsync();
            var outDtos = _mapper.Map<List<ReaderOutDto>>(entities);
            return Ok(outDtos);
        }
        // --------------------------------------------------------CreateAsync--------------------------------------------------------------------------- //
        [HttpPost("[action]")]
        [Consumes("application/json")]
        public async Task<ActionResult<ReaderOutDto>>CreateAsync([FromBody] CreateReaderDto createDto)
        {
            var reader = _mapper.Map<Reader>(createDto);
            var entity = (await dbContext.Set<Reader>().AddAsync(reader)).Entity;
            await dbContext.SaveChangesAsync();
            var outDtos = _mapper.Map<ReaderOutDto>(entity);
            return Created(Request.Path, outDtos);
        }
        // --------------------------------------------------------UpdateAsync--------------------------------------------------------------------------- //
        [HttpPut("[action]/{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<ReaderOutDto>>UpdateAsync(
                [FromRoute] int id,
                [FromBody] UpdateReaderDto updateDto)
        {
            var reader = _mapper.Map<Reader>(updateDto);
            var entity = dbContext.Set<Reader>().Update(reader).Entity;
            await dbContext.SaveChangesAsync();
            var outDto = _mapper.Map<ReaderOutDto>(entity);
            return Ok(outDto);
        }
        // --------------------------------------------------------RemoveAsync----------------------------------------------------------------------------//
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> RemoveAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Reader>().SingleAsync(x => x.Id.Equals(id));
            dbContext.Set<Reader>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
