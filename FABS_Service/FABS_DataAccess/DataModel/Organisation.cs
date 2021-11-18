using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Organisation
    {
        public Organisation(string cvr, string name, Address addresses) : this()
        {
            Cvr = cvr;
            Name = name;
            Addresses = addresses;
        }

        public Organisation(string cvr, string name, int addressesId)
        {
            Cvr = cvr;
            Name = name;
            AddressesId = addressesId;
        }
    }
}
