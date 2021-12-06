
//using Newtonsoft.Json;
using FABS_Client_WPF.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace FABS_Client_WPF.BusinessLogic
{
    class PersonHelper
    {
        /// <summary>
        /// Logic for creating a REST Client in order to save a person in the database
        /// </summary>
        private IRestClient _clientPeople = new RestClient("https://localhost:44309/api");
        internal void PostPerson(PersonDto person)
        {
            try
            {
                var request = new RestRequest("people/?organisationId=1", Method.POST, DataFormat.Json);
                request.AddJsonBody(JsonSerializer.Serialize(person));

                var response = _clientPeople.Execute(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
