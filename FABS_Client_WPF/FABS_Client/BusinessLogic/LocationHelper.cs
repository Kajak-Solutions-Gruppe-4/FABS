using FABS_Client_WPF.DTO;
//using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FABS_Client_WPF.BusinessLogic
{
    class LocationHelper
    {
        private IRestClient _clientLocation = new RestClient("https://localhost:44309/api");
        internal void PostLocation(LocationDto location)
        {
            try
            {
                var request = new RestRequest("locations/?organisationId=1", Method.POST, DataFormat.Json);
                request.AddJsonBody(JsonSerializer.Serialize(location));

                var response = _clientLocation.Execute(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
