using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class AssociationPerson
    {
        public AssociationPerson(Association associations, Person people) : this()
        {
            Association = associations;
            Person = people;
        }

        public AssociationPerson()
        {

        }
    }
}
