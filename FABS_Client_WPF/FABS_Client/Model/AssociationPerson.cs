using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_Client_WPF.Model
{
    public partial class AssociationPerson
    {
        public int AssociationId { get; set; }
        public int PersonId { get; set; }

        public virtual Association Association { get; set; }
        public virtual Person Person { get; set; }
    }
}
