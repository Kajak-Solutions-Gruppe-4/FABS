using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_Client_WPF.Model
{
    public partial class Person
    {
        public Person(string firstName, string lastName, string telephoneNumber, bool isAdmin, Address adresses, Login login) : this()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephoneNumber = telephoneNumber;
            this.isAdmin = isAdmin;
            this.addresses = adresses;
            this.login = login;
        }

        public Person(string firstName, string lastName, string telephoneNumber, bool isAdmin, int adressesId, Login login) : this()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.telephoneNumber = telephoneNumber;
            this.adressesId = adressesId;
            this.login = login;
            this.isAdmin = isAdmin;
        }
    }
}
