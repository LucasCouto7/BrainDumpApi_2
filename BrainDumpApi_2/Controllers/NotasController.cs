using BrainDumpApi_2.Context;
using Microsoft.AspNetCore.Mvc;

namespace BrainDumpApi_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly BrainDumpApiContext _context;

        public NotasController(BrainDumpApiContext context)
        {
            _context = context;
        }
    }
}
