using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegFormApi.Models;

namespace RegFormApi.Controllers.Api
{
    [Route("api/persons")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(_dbContext.Persons.ToList());
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            _dbContext.Add(person);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
