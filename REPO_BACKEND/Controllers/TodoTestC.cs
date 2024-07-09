using backnc.Data;
using backnc.Data.POCOEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace backnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTestC : ControllerBase
    {
        private readonly AppDbContext _context;
        public TodoTestC(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create-todo")]
        public async Task<IActionResult> createtest([FromBody]TodoTest todo)
        {
                
            _context.todoTests.Add(todo);
            await _context.SaveChangesAsync();
            return Ok(todo.Id);
            
        }

        [HttpGet("getall-todo")]
        public  IActionResult getalltodo()
        {
            return Ok(_context.todoTests.ToList());
        }
    }
}
