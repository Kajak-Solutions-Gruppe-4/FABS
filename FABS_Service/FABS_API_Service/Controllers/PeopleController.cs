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
        private readonly IRepository<ZipcodeCountryCity> _zipcodeCountryCityRepository;
        private readonly IRepository<Address> _addressRepository;

        [ActivatorUtilitiesConstructor]
        public PeopleController()
        {
            _peopleRepository = new PeopleRepository();
            _zipcodeCountryCityRepository = new ZipcodeCountryCityRepository();
            _addressRepository = new AddressRepository();
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
            Person foundPerson = _peopleRepository.Get(new PrimaryKey(id), organisationId);
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
                //NOTE: do we really need to tell the user the id?
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
            bool wasOk = _peopleRepository.Update(new PrimaryKey(id), p);
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
            var wasOk = _peopleRepository.Delete(new PrimaryKey(id));
            if (wasOk)
            {
                return Ok();
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        private PersonDto ConvertModelToDto(Person model)
        {
            AddressDto addressDto = new AddressDto(
                model.Addresses.Id,
                model.Addresses.StreetName,
                model.Addresses.StreetNumber,
                model.Addresses.ApartmentNumber,
                model.Addresses.ZipcodeCountryCity.Zipcode,
                model.Addresses.ZipcodeCountryCity.Countries.Id,
                model.Addresses.ZipcodeCountryCity.Countries.Name,
                model.Addresses.ZipcodeCountryCity.City
                );
            PersonDto personDto = new PersonDto(
                model.Id,
                model.FirstName,
                model.LastName,
                model.TelephoneNumber,
                addressDto,
                model.Login.Email
                );
            return personDto;
        }

        private Person ConvertDtoToModel(PersonDto dto, int organisationId)
        {
            Person person = new Person();
            person.FirstName = dto.FirstName;
            person.LastName = dto.FirstName;
            person.TelephoneNumber = dto.TelephoneNumber;
            person.IsAdmin = false;

            Address address = new Address(
                dto.Address.StreetName,
                dto.Address.StreetNumber,
                dto.Address.ApartmentNumber,
                dto.Address.Zipcode,
                dto.Address.CountryId
                );
            PrimaryKey addressPrimaryKey = _addressRepository.FindPrimaryKey(address);
            int currentAddressIdInContext = (int) addressPrimaryKey.KeyValues[0];
            if(currentAddressIdInContext > 0)
            {
                // if address already exists in database, use that address.
                person.AddressesId = currentAddressIdInContext;
            }
            else
            {
                ZipcodeCountryCity zipcodeCountryCity = new ZipcodeCountryCity(
                    dto.Address.Zipcode,
                    dto.Address.CountryId,
                    dto.Address.City
                    );
                PrimaryKey zipcodeCountryCityPrimaryKey = _zipcodeCountryCityRepository.FindPrimaryKey(zipcodeCountryCity);
                if(zipcodeCountryCityPrimaryKey != null)
                {
                    // if address does not already exist in database, but the Zipcode does, create new address with existing zipcode
                    person.Addresses = address;
                }
                else
                {
                    // if neither address or zipcode exist in database, create both.
                    address.ZipcodeCountryCity = zipcodeCountryCity;
                    person.Addresses = address;
                }
            }

            Login login = new Login(
                dto.Email,
                "1234"
                );
            person.Login = login;

            OrganisationPerson organisationPerson = new OrganisationPerson(
                organisationId,
                dto.Id
                );
            person.OrganisationPeople.Add(organisationPerson);
            return person;
        }
    }
}
