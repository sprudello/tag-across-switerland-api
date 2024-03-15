using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("GetAllTransportations")]
        public async Task<IActionResult> GetAllTransportationsMethods()
        {
            var transportations = await _context.Transportations.ToListAsync();
            if(transportations.Count == 0)
            {
                return NotFound("No TransportationTypes found");
            }
            return Ok(transportations);
        }
        [HttpPost("CreateTransportation")]
        public async Task<IActionResult> PostNewTransportation([FromBody] TransportationDTO request)
        {
            var newTransportation = new TransportationType
            {
                TypeName = request.TypeName,
                FeePerMinute = request.FeePerMinute,
            };

            _context.Transportations.AddAsync(newTransportation);
            _context.SaveChanges();

            return Ok("Creation was successful");
        }
    }
}
