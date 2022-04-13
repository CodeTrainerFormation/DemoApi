using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Filters;
using DomainModel;
using Dal;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonAsyncController : ControllerBase
    {
        private readonly SchoolContext context;

        public PersonAsyncController(SchoolContext context)
        {
            this.context = context;
        }

        // GET : /Person
        [HttpGet]
        public async Task<ActionResult<List<Person>>> RetrieveAllPeople()
        {
            return Ok(await this.context.People.ToListAsync());
        }

        // GET : /Person/5
        //[MyFilter]
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> RetrievePerson(int id)
        {
            if (id <= 0)
                return BadRequest();

            // get from database
            //var person = this.context.People.SingleOrDefaultAsync(p => p.PersonId == id);
            Person person = await this.context.People.FindAsync(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST : /Person
        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            // insert to db
            await this.context.People.AddAsync(person);
            await this.context.SaveChangesAsync();

            return CreatedAtAction(nameof(RetrievePerson), new { id = person.PersonId }, person);
        }

        // PUT : /Person/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            if(id != person.PersonId)
                return BadRequest();

            // update person in db
            this.context.People.Update(person);
            await this.context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE : /Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePerson(int id)
        {
            var personToDelete = await this.context.People.SingleOrDefaultAsync(p => p.PersonId == id);

            if (personToDelete == null)
                return NotFound();

            // delete person in db
            this.context.People.Remove(personToDelete);
            await this.context.SaveChangesAsync();

            return Ok(personToDelete);
        }
    }
}
