﻿using library_db_book.Models;
using library_db_book.Models.Class_Book;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // --------------------------------------------------------GetByIdAsync-------------------------------------------------------------------------- //
        [HttpGet("{id}")]
        public async Task<ActionResult<ShelfOutDto>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Shelf>().SingleAsync(x => x.Id.Equals(id));
            var outDtos = _mapper.Map<Shelf>(entity);
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
        public async Task<ActionResult<ShelfOutDto>> CreateAsync([FromBody] CreateShelfDto createDto)
        {
            var createshelfDto = _mapper.Map<Shelf>(createDto);
            var entity = (await dbContext.Set<Shelf>().AddAsync(createshelfDto)).Entity;
            await dbContext.SaveChangesAsync();
            var outDtos = _mapper.Map<Shelf>(entity);
            return Created(Request.Path, outDtos);
        }
        // --------------------------------------------------------UpdateAsync--------------------------------------------------------------------------- //
        [HttpPut("[action]/{id}")]
        [Consumes("application/json")]
        public async Task<ActionResult<ShelfOutDto>> UpdateAsync(
                [FromRoute] int id,
                [FromBody] UpdateShelfDto updateDto)
        {
            var updateshelfDto = _mapper.Map<Shelf>(updateDto);
            var entity = dbContext.Set<Shelf>().Update(updateshelfDto).Entity;
            await dbContext.SaveChangesAsync();
            var outDto = _mapper.Map<Shelf>(entity);
            return Ok(outDto);
        }
        // --------------------------------------------------------RemoveAsync----------------------------------------------------------------------------//
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> RemoveAsync([FromRoute] int id)
        {
            var entity = await dbContext.Set<Shelf>().SingleAsync(x => x.Id.Equals(id));
            var outDto = dbContext.Set<Shelf>().Remove(entity).Entity;
            return Ok();
        }
    }
}
