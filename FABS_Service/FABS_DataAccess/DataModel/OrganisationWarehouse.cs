using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class OrganisationWarehouse
    {
        public OrganisationWarehouse()
        {
        }
        
        public OrganisationWarehouse(Organisation organisation, Warehouse warehouses) : this()
        {
            Organisations = organisation;
            Warehouses = warehouses;
        }
    }
}
