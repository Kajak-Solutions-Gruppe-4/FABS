using FABS_Client_WPF.DTO;
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FABS_Client_WPF.BusinessLogic
{
    class ItemHelper
    {
        /// <summary>
        /// Creates a REST Client in order to save an item in the database
        /// </summary>
        private IRestClient _clientItem = new RestClient("https://localhost:44309/api");
        internal void PostItem(ItemDto item)
        {
            try
            {
                var request = new RestRequest("items/?organisationId=1", Method.POST, DataFormat.Json);
                request.AddJsonBody(JsonSerializer.Serialize(item));

                var response = _clientItem.Execute(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
