using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class AssociationPerson
    {
        public int AssociationsId { get; set; }
        public int PeopleId { get; set; }

        public virtual Association Associations { get; set; }
        public virtual Person People { get; set; }
    }
}
