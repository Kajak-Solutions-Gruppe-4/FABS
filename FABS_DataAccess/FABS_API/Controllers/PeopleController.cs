using FABS_DataAccess.Model;
using FABS_DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FABS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private PeopleRepository _PeopleRepository = new PeopleRepository();


        // GET: api/<PeopleController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            //Implement fail-logic
            var result = _PeopleRepository.GetAll();
            return result;
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            var result = _PeopleRepository.Get(id);
            return result;
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post(Person value)
        {
            var result = _PeopleRepository.Create(value);
            //return result;
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
