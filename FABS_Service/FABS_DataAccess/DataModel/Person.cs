using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Person
    {
        public Person(string firstName, string lastName, string telephoneNumber, bool isAdmin, Address adresses, Login logins)
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            IsAdmin = isAdmin;
            Adresses = adresses;
            Logins = logins;
        }
    }
}
