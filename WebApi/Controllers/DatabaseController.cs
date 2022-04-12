using Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class DatabaseController : ControllerBase
    {
        private readonly SchoolContext context;

        public DatabaseController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Create(bool delete = false)
        {
            if(delete)
                this.context.Database.EnsureDeleted();

            this.context.Database.EnsureCreated();

            return Ok();
        }
    }
}
