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
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Item> _itemRepository;

        public ItemsController()
        {
            _itemRepository = new ItemRepository();
        }

        // GET: api/<ItemsController>
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get(int organisationId)
        {
            if (organisationId <= 0)
            {
                return new StatusCodeResult(422);
            }
            IEnumerable<Item> listItems = _itemRepository.GetAll(organisationId);
            List<ItemDto> items = new List<ItemDto>();
            foreach (Item item in listItems)
            {
                items.Add(ConvertModelToDto(item));
            }

            int c = items.Count();
            if (c < 0)
            {
                return NotFound();
            }
            return Ok(items);
        }



        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public string Get(int id, int organisationId)
        {
            return "value";
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        private ItemDto ConvertModelToDto(Item item)
        {
            //Getting the item
            int id = item.Id;

            OrganisationDto organisationDto = new OrganisationDto(
                item.Organisations.Id,
                item.Organisations.Cvr,
                item.Organisations.Name
                );

            //Check if item has a status
            StatusDto statusDto = null;
            if (item.Statuses != null)
            {
                statusDto = new StatusDto(
                item.Statuses.Id,
                item.Statuses.Name,
                item.Statuses.Category
                );
            }
            //Check if item has a location
            LocationDto locationDto = null;
            if (item.Locations != null)
            {
                locationDto = new LocationDto(
                item.Locations.Id,
                item.Locations.PickLocation,
                item.Locations.Description
                );
            }
            ItemTypeDto itemTypeDto = null;
            if (item.ItemTypes != null)
            {
                itemTypeDto = new ItemTypeDto(
                    item.ItemTypes.Id,
                    item.ItemTypes.Name
                    );
            }

            ItemDto itemDto = new ItemDto(
                id,
                organisationDto,
                statusDto,
                locationDto,
                itemTypeDto
                );

            return itemDto;

        }
    }
}
