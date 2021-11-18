using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Person
    {

        public Person(string firstName, string lastName, string telephoneNumber, bool isAdmin, Address adresses, Login logins) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            IsAdmin = isAdmin;
            Addresses = adresses;
            Login = logins;
        }

        public Person(string firstName, string lastName, string telephoneNumber, bool isAdmin, int adressesId, Login login) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            AdressesId = adressesId;
            Login = login;
            IsAdmin = isAdmin;
        }
    }
}
