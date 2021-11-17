using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.Model
{
    public partial class Person

    {
        public Person()
        {

        }

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public int adressesId { get; set; }
        public int loginsId { get; set; }
        public bool isAdmin { get; set; }
        public Address addresses { get; set; }
        public Login login { get; set; }

    }
}
