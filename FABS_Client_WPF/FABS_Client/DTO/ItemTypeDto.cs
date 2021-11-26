using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace FABS_Client_WPF.DTO
{
    public class ItemTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public KayakTypeDto KayakTypesId { get; set; }

        public ItemTypeDto()
        {

        }

        public ItemTypeDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ItemTypeDto(string name, KayakTypeDto kayakType)
        {
            Name = name;
            KayakTypesId = kayakType;
        }
    }
}