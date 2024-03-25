using Azure.Core;
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
    public class TransportationsContoller : ControllerBase
    {
        private readonly DataContext _context;
        public TransportationsContoller(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllTransportations/")]
        public async Task<IActionResult> GetAllTransportationsMethods()
        {
            var transportations = await _context.Transportations.ToListAsync();
            if (transportations.Count == 0)
            {
                return NotFound(new { message = "No TransportationTypes found" });
            }
            return Ok(transportations);
        }
        [HttpPost("CreateTransportation/")]
        public async Task<IActionResult> PostNewTransportation([FromBody] TransportationDTO request)
        {
            var newTransportation = new TransportationType
            {
                TypeName = request.TypeName,
                FeePerMinute = request.FeePerMinute,
            };

            await _context.Transportations.AddAsync(newTransportation);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Creation was successful" });
        }
        [HttpPost("BuyTransportation/")]
        public async Task<IActionResult> BuyTransportation([FromBody] BuyTransportationDTO request)
        {
            string username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new { message = "User is not authenticated." });
            }
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Username == username);
            if (user.PenaltyEndTime > DateTime.UtcNow)
            {
                return BadRequest(new { message = $"You still have a penalty until {user.PenaltyEndTime.AddHours(1).TimeOfDay}" });
            }
            var transportation = _context.Transportations.FirstOrDefault(c => c.TypeName == request.TransportationTitle);
            if (transportation == null)
            {
                return NotFound(new { message = "Transportation Method not found" });
            }
            int fee = transportation.FeePerMinute * request.TimeInMinutes;
            if (fee > user.GottstattCoins)
            {
                return Ok(new { message = "Insufficient Funds" });
            }
            user.GottstattCoins -= fee;
            UserTransportation newTransport = new UserTransportation
            {
                UserID = user.Id,
                TypeID = transportation.Id,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddMinutes(request.TimeInMinutes),
                Duration = request.TimeInMinutes,
                TotalCost = fee,
            };
            _context.UserTransportations.Add(newTransport);
            await _context.SaveChangesAsync();
            return Ok(new { message = $"Ride booked successfully, fee: {fee} GottstattCoins" });
        }
    }
}
