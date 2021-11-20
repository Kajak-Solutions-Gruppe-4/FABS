using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class ItemType
    {
        public ItemType(string name, KayakType kayakType) : this()
        {
            Name = name;
            KayakType = kayakType;
        }
    }
}
