using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.Model
{
    public partial class Association
    {
        public Association(string cvr, string name, Address addresses) : this()
        {
            Cvr = cvr;
            Name = name;
            Addresses = addresses;
        }
    }
}
