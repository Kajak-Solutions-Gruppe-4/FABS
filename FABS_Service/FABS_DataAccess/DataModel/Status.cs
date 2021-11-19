using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Status
    {
        public Status(string name, string category) : this()
        {
            Name = name;
            Category = category;
        }
    }
}
