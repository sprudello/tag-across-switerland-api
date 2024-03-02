using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagAPI.Data;

namespace TagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationsContoller : ControllerBase
    {
        private readonly DataContext _context;
        public TransportationsContoller(DataContext context)
        {
            _context = context;
        }
    }
}
