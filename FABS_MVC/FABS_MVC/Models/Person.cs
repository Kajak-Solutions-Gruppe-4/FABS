using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FABS_MVC.Models
{
    public class Person
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("telephoneNumber")]
        public string TelephoneNumber { get; set; }
        [JsonPropertyName("adressesId")]
        public int AdressesId { get; set; }
        [JsonPropertyName("loginsId")]
        public int LoginsId { get; set; }
        [JsonPropertyName("isAdmin")]
        public bool IsAdmin { get; set; }


        public Person()
        {
        }

        public Person(string firstName, string lastName, string telephoneNumber, int adressesId, int loginsId, bool isAdmin)
        {
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
            AdressesId = adressesId;
            LoginsId = loginsId;
            IsAdmin = isAdmin;
        }

        public override string ToString()
        {
            return $"{Id} - {FirstName} {LastName}, {TelephoneNumber}";
        }
    }
}
