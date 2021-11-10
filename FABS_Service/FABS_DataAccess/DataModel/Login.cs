using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Login
    {
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
