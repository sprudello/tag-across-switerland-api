using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagAPI.Data;

namespace TagAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PenaltiesController : ControllerBase
    {
        private readonly DataContext _context;
    }
}
