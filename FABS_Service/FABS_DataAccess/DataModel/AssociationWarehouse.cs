using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class AssociationWarehouse
    {
        public AssociationWarehouse(Association associations, Warehouse warehouses)
        {
            Associations = associations;
            Warehouses = warehouses;
        }
    }
}
