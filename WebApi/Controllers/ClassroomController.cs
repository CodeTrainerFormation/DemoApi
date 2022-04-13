using Dal;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly SchoolContext context;

        public ClassroomController(SchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Classroom>>> GetClassrooms()
        {
            return Ok(await this.context.Classrooms.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Classroom>> PostClassroom(Classroom classroom)
        {
            this.context.Classrooms.Add(classroom);
            await this.context.SaveChangesAsync();

            return Ok(classroom);
        }
    }
}
