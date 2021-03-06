using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class ItemType
    {
        public ItemType(string name, KayakType kayakType) : this(name)
        {
            KayakType = kayakType;
        }

        public ItemType(string name) : this()
        {
            Name = name;
        }
    }
}
