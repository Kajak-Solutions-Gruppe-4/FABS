using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class OrganisationPerson
    {
        public OrganisationPerson(Organisation organisation, Person people) : this()
        {
            Organisations = organisation;
            Person = people;
        }

        public OrganisationPerson()
        {
        }
    }
}
