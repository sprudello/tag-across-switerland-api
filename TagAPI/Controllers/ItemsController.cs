using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TagAPI.Data;
using TagAPI.Models;
using TagAPI.ModelsDTO;

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
        [HttpPost("CrateNewItem/")]
        public async Task<IActionResult> CreateNewItem([FromBody] ItemDTO request)
        {
            Item item = new Item
            {
                ItemName = request.ItemName,
                Description = request.Description,
                ItemPrice = request.ItemPrice,
            };
            _context.Items.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }
        [HttpPost("BuyItem/")]
        public async Task<IActionResult> BuyItem([FromBody] BuyItemDTO request)
        {
            string username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("User is not authenticated.");
            }
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Username == username);
            var item = await _context.Items.FirstOrDefaultAsync(c => c.ItemName == request.ItemName);
            if(item == null)
            {
                return NotFound(new { message = "Item no existo." });
            }
            if (item.ItemName == "Double")
            {
                if (_context.UserChallenges.Where(c => c.UserID == user.Id && c.Status == "started").Any())
                {
                    return BadRequest(new { message = "You can't buy this item while having an active quest." });
                }
                user.HasMultiplier = true;
            }
            user.GottstattCoins -= item.ItemPrice;
            UserItem userItem = new UserItem
            {
                UserID = user.Id,
                ItemID = item.Id,
                PurchaseDate = DateTime.UtcNow,
            };
            _context.UserItems.Add(userItem);
            _context.SaveChanges();
            return Ok(new { message = $"Item bought successfully for {item.ItemPrice}" });
        }
    }
   
}
    
