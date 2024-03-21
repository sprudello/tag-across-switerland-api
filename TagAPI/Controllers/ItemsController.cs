using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagAPI.Data;

namespace TagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _context;
        public ItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllItems/")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _context.Items.ToListAsync();
            if (items == null || items.Count == 0)
            {
                return NotFound(new { message = "No Items Found" });
            }
            return Ok(items);
        }
    }
   
}
    
