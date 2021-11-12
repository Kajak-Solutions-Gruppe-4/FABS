using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class Login
    {
        public int PeopleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Person Person { get; set; }
    }
}
