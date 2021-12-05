using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Warehouse
    {
        public Warehouse(string name, Address address)
        {
            Name = name;
            Addresses = address;
        }

        public Warehouse(string name, int addressesId)
        {
            Name = name;
            AddressesId = addressesId;
        }

        public Warehouse(string name)
        {
            Name = name;
        }
    }
}