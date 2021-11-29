using FABS_Client_WPF.DTO;
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FABS_Client_WPF.BusinessLogic
{
    class ItemTypeHelper
    {
        private IRestClient _clientItemType = new RestClient("https://localhost:44309/api");
        internal void PostItemType(ItemTypeDto itemType)
        {
            try
            {
                var request = new RestRequest("itemTypes/?organisationId=1", Method.POST, DataFormat.Json);
                request.AddJsonBody(JsonSerializer.Serialize(itemType));

                var response = _clientItemType.Execute(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
