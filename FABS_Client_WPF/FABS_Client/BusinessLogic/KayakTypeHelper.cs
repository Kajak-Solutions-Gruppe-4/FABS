using FABS_Client_WPF.DTO;
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FABS_Client_WPF.BusinessLogic
{
    class KayakTypeHelper
    {
        private IRestClient _clientKayakType = new RestClient("https://localhost:44309/api");
        internal void PostKayakType(KayakTypeDto kayakType)
        {
            try
            {
                var request = new RestRequest("kayakTypes/?organisationId=1", Method.POST, DataFormat.Json);
                request.AddJsonBody(JsonSerializer.Serialize(kayakType));

                var response = _clientKayakType.Execute(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
