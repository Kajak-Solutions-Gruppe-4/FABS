using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Association
    {
        public Association(string cvr, string name, Address addresses)
        {
            Cvr = cvr;
            Name = name;
            Addresses = addresses;
        }
    }
}
