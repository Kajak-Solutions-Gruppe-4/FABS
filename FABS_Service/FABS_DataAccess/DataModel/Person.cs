using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Person
    {

        public Person(string firstName, string lastName, string telephoneNumber, bool isAdmin, Address addresses, Login logins) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            IsAdmin = isAdmin;
            Addresses = addresses;
            Login = logins;
        }

        public Person(string firstName, string lastName, string telephoneNumber, bool isAdmin, int addressesId, Login login) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            AddressesId = addressesId;
            Login = login;
            IsAdmin = isAdmin;
        }
    }
}
