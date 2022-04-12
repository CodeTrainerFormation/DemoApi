using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Filters;
using DomainModel;
using Dal;

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
        public IActionResult RetrieveAllPeople()
        {
            return Ok(this.context.People.ToList());
        }

        // GET : /Person/5
        //[MyFilter]
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult RetrievePerson(int id)
        {
            if (id <= 0)
                return BadRequest();

            // get from database
            var person = this.context.People.SingleOrDefault(p => p.PersonId == id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST : /Person
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            // insert to db
            this.context.People.Add(person);
            this.context.SaveChanges();

            return CreatedAtAction(nameof(RetrievePerson), new { id = person.PersonId }, person);
        }

        // PUT : /Person/5
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            if(id != person.PersonId)
                return BadRequest();

            // update person in db
            this.context.People.Update(person);
            this.context.SaveChanges();

            return NoContent();
        }

        // DELETE : /Person/5
        [HttpDelete("{id}")]
        public IActionResult RemovePerson(int id)
        {
            var personToDelete = this.context.People.SingleOrDefault(p => p.PersonId == id);

            if (personToDelete == null)
                return NotFound();

            // delete person in db
            this.context.People.Remove(personToDelete);
            this.context.SaveChanges();

            return Ok(personToDelete);
        }
    }
}
