using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FABS_DataAccess.Repository;
using FABS_DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FABS_API_Service.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FABS_API_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IRepository<Person> _peopleRepository;

        [ActivatorUtilitiesConstructor]
        public PeopleController()
        {
            _peopleRepository = new PeopleRepository("Hildur");
        }
        // GET: api/<PeopleController>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get(int organisationId)
        {
            if(organisationId <= 0)
            {
                return new StatusCodeResult(422);
            }
            IEnumerable<Person> listPeople = _peopleRepository.GetAll(organisationId);
            List<PersonDto> people = new List<PersonDto>();
            foreach (Person person in listPeople)
            {
                people.Add(ConvertModelToDto(person));
            }

            int c = people.Count();
            if (c < 0)
            {
                return NotFound();
            }
            return Ok(people);
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public ActionResult<PersonDto> Get(int id, int organisationId)
        {
            if (organisationId <= 0)
            {
                return new StatusCodeResult(422);
            }
            Person foundPerson = _peopleRepository.Get(id, organisationId);
            if (foundPerson != null)
            {
                PersonDto personDto = ConvertModelToDto(foundPerson);
                return Ok(personDto);
            }
            else
            {
                return new StatusCodeResult(404);
            }


        }



        // POST api/<PeopleController>
        [HttpPost]
        public ActionResult<int> Post(PersonDto pDto, int organisationId)
        {
            Person p = ConvertDtoToModel(pDto, organisationId);
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

        private PersonDto ConvertModelToDto(Person person)
        {
            AddressDto addressDto = new AddressDto(
                person.Addresses.Id,
                person.Addresses.StreetName,
                person.Addresses.StreetNumber,
                person.Addresses.ApartmentNumber,
                person.Addresses.ZipcodeCountryCity.Zipcode,
                person.Addresses.ZipcodeCountryCity.Countries.Id,
                person.Addresses.ZipcodeCountryCity.Countries.Name,
                person.Addresses.ZipcodeCountryCity.City
                );
            PersonDto personDto = new PersonDto(
                person.Id,
                person.FirstName,
                person.LastName,
                person.TelephoneNumber,
                addressDto,
                person.Login.Email
                );
            return personDto;
        }

        private Person ConvertDtoToModel(PersonDto dto, int organisationId)
        {
            ZipcodeCountryCity zipcodeCountryCity = new ZipcodeCountryCity(
                dto.Address.Zipcode,
                dto.Address.CountryId,
                dto.Address.City
                );
            Address address = new Address(
                dto.Address.StreetName,
                dto.Address.StreetNumber,
                dto.Address.ApartmentNumber,
                zipcodeCountryCity
                );
            OrganisationPerson organisationPerson = new OrganisationPerson(
                organisationId,
                dto.Id
                );
            Login login = new Login(
                dto.Email,
                "1234"
                );
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.TelephoneNumber,
                false,
                address,
                login
                );
            person.OrganisationPeople.Add(organisationPerson);
            return person;
        }
    }
}
