using System;
using System.Collections.Generic;

#nullable disable

namespace FABS_Client_WPF.Model
{
    public partial class AssociationWarehouse
    {
        public int AssociationsId { get; set; }
        public int WarehousesId { get; set; }

        public virtual Association Associations { get; set; }
        public virtual Warehouse Warehouses { get; set; }
    }
}
