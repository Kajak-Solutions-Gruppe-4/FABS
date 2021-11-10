using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FABS_DataAccess.Repository;
using FABS_DataAccess.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FABS_API_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Person> _peopleRepository;

        public PeopleController()
        {
            _peopleRepository = new PeopleRepository();
        }
        // GET: api/<PeopleController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            IEnumerable<Person> listPeople = _peopleRepository.GetAll();
            int c = listPeople.Count();
            if (c < 0)
            {
                return NotFound();
            }
            return Ok(listPeople);
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            ActionResult<Person> foundPerson = _peopleRepository.Get(id);
            if (foundPerson != null)
            {
                return Ok(foundPerson);
            }
            else
            {
                return new StatusCodeResult(500);
            }


        }



        // POST api/<PeopleController>
        [HttpPost]
        public ActionResult<int> Post(Person p)
        {
            int newPersonId = _peopleRepository.Create(p);
            if (newPersonId > -1)
            {
                return Ok(newPersonId);
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }


        //TODO: Right now the put method create a new person in database rather than updating existing. 
        //Test implementation of Update in the repository

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Person p)
        {
            bool wasOk = _peopleRepository.Update(id, p);
            if (wasOk)
            {
                return Ok();
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var wasOk = _peopleRepository.Delete(id);
            if (wasOk)
            {
                return Ok();
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
