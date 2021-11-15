using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_DataAccess.Model
{
    public partial class OrganisationWarehouse
    {
        public int OrganisationsId { get; set; }
        public int WarehousesId { get; set; }

        public virtual Organisation Organisations { get; set; }
        public virtual Warehouse Warehouses { get; set; }
    }
}
