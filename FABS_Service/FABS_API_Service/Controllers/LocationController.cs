using FABS_API_Service.DTO;
using FABS_DataAccess.Model;
using FABS_DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FABS_API_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IRepository<Location> _locationRepository;

        public LocationController()
        {
            _locationRepository = new LocationRepository("Hildur");
        }

        // GET: api/<LocationController>
        [HttpGet]
        public ActionResult<IEnumerable<Location>> Get(int organisationId)
        {
            if (organisationId <= 0)
            {
                return new StatusCodeResult(422);
            }
            IEnumerable<Location> listLocation = _locationRepository.GetAll(organisationId);
            List<LocationDto> locations = new List<LocationDto>();
            foreach (Location location in listLocation)
            {
                locations.Add(ConvertModelToDto(location));
            }

            int c = locations.Count();
            if (c < 0)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public string Get(int id, int organisationId)
        {
            return "value";
        }

        // POST api/<LocationController>
        [HttpPost]
        public ActionResult<int> Post(LocationDto lDto, int organisationId)
        {
            Location l = ConvertDtoToModel(lDto, organisationId);
            int newLocationId = _locationRepository.Create(l);
            if (newLocationId > -1)
            {
                return Ok(newLocationId);
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private LocationDto ConvertModelToDto(Location location)
        {
            AddressDto wAddress = new AddressDto(
                
                );
            WarehouseDto warehouseDto = new WarehouseDto(
                location.Warehouses.Id,
                location.Warehouses.Name,
                wAddress
                );
            PersonDto personDto = new PersonDto(
                
                );
            OrganisationDto organisationDto = new OrganisationDto(
                
                );
            LocationDto locationDto = new LocationDto(
                location.Id,
                location.PickLocation,
                location.Description,
                warehouseDto,
                personDto,
                organisationDto
                );
            return locationDto;
        }


        private Location ConvertDtoToModel(LocationDto lDto, int organisationId)
        {
            throw new NotImplementedException();
        }
    }
}
