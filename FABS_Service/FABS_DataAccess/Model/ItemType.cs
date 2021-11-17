using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class ItemType
    {
        public ItemType()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual KayakType IdNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
