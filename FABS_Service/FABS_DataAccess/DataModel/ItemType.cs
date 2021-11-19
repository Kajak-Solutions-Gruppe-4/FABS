using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{

    public partial class ItemType
    {
        public ItemType(String name, KayakType kayakType) : this()
        {
            Name = name;
            KayakTypes = kayakType;
        }
    }
}
