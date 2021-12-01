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
    public class ItemTypesController : ControllerBase
    {
        private readonly IRepository<ItemType> _itemTypeRepository;

        public ItemTypesController()
        {
            _itemTypeRepository = new ItemTypeRepository();
        }
        // GET: api/<ItemTypesController>
        [HttpGet]
        public ActionResult<IEnumerable<ItemType>> Get(int organisationId)
        {
            if (organisationId <= 0)
            {
                return new StatusCodeResult(422);
            }
            IEnumerable<ItemType> listItemType = _itemTypeRepository.GetAll(organisationId);


            ////Add this when DTO is running uncommet what is commented
            List<ItemTypeDto> itemTypes = new List<ItemTypeDto>();
            foreach (ItemType it in listItemType)
            {
               itemTypes.Add(ConvertModelToDto(it));
            }

            int c = itemTypes.Count();

            //int c = listItemType.Count();
            //if (c < 0)
            //{
            //    return NotFound();
            //}
            return Ok(itemTypes);
            //return Ok(listItemType);

        }

        // GET api/<ItemTypesController>/5
        [HttpGet("{id}")]
        public string Get(int id, int organisationId)
        {
            return "value";
        }

        // POST api/<ItemTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private ItemTypeDto ConvertModelToDto(ItemType itemType)
        {

            KayakTypeDto kayakTypeDto = null;
            if (itemType.KayakType != null)
            {
                kayakTypeDto = new KayakTypeDto(
                null,
                itemType.KayakType.Description,
                itemType.KayakType.WeightLimit,
                itemType.KayakType.LengthMeter,
                itemType.KayakType.PersonCapacity);
            }



            ItemTypeDto itemTypeDto = new ItemTypeDto(
                itemType.Id, 
                itemType.Name, 
                kayakTypeDto);

            kayakTypeDto.ItemTypesId = itemTypeDto;
        
            return itemTypeDto;
        }

    }
}
