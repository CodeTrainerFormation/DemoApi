using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Filters;
using DomainModel;

namespace WebApi.Controllers
{
    //[MyFilter]
    [Route("[controller]")]
    [ApiController]
    public class PersonMemoryController : ControllerBase
    {
        private static List<Person> people;

        static PersonMemoryController()
        {
            people = new List<Person>()
            {
                new Person()
                {
                    PersonId = 1,
                    FirstName = "Ted",
                    LastName = "Mosby",
                    Age = 35
                },
                new Person()
                {
                    PersonId = 2,
                    FirstName = "Barney",
                    LastName = "Stinson",
                    Age = 38
                },
                new Person()
                {
                    PersonId = 3,
                    FirstName = "Lily",
                    LastName = "Aldrin",
                    Age = 36
                }
            };
        }

        // GET : /PersonMemory
        [HttpGet]
        public IActionResult RetrieveAllPeople()
        {
            return Ok(people);
        }

        // GET : /PersonMemory/5
        //[MyFilter]
        //[Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult RetrievePerson(int id)
        {
            if (id <= 0)
                return BadRequest();

            // get from database
            var person = people.SingleOrDefault(p => p.PersonId == id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST : /PersonMemory
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            // insert to db
            person.PersonId = people.Last().PersonId + 1;
            people.Add(person);

            return CreatedAtAction(nameof(RetrievePerson), new { id = person.PersonId }, person);
        }

        // PUT : /PersonMemory/5
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            if(id != person.PersonId)
                return BadRequest();

            // update person in db
            var personToUpdate = people.SingleOrDefault(p => p.PersonId == id);
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.Age = person.Age;

            return NoContent();
        }

        // DELETE : /PersonMemory/5
        [HttpDelete("{id}")]
        public IActionResult RemovePerson(int id)
        {
            var personToDelete = people.SingleOrDefault(p => p.PersonId == id);

            if (personToDelete == null)
                return NotFound();

            // delete person in db
            people.Remove(personToDelete);

            return Ok(personToDelete);
        }
    }
}
