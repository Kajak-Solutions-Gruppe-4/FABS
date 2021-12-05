using FABS_Client_WPF.DTO;
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FABS_Client_WPF.BusinessLogic
{
    class WarehouseHelper
    {
        private IRestClient _clientWarehouse = new RestClient("https://localhost:44309/api");
        internal void PostWarehouse(WarehouseDto warehouse)
        {
            try
            {
                var request = new RestRequest("warehouses/?organisationId=1", Method.POST, DataFormat.Json);
                request.AddJsonBody(JsonSerializer.Serialize(warehouse));

                var response = _clientWarehouse.Execute(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
