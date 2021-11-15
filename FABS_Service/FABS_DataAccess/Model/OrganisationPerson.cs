using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class OrganisationPerson
    {
        public int OrganisationsId { get; set; }
        public int PersonId { get; set; }

        public virtual Organisation Organisations { get; set; }
        public virtual Person Person { get; set; }
    }
}
