using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_API_Service.DTO
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }

        public WarehouseDto()
        {

        }

        public WarehouseDto(int id, string name, AddressDto address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public WarehouseDto(string name, AddressDto address)
        {
            Name = name;
            Address = address;
        }

        public WarehouseDto(string name)
        {
            Name = name;
        }
    }
}
