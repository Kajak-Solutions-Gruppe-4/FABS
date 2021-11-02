using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FABS_WPF_Client.Model
{
    class Person
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("telephoneNumber")]
        public string TelephoneNumber { get; set; }

        public Person()
        {
        }

        public Person(int id, string firstName, string lastName, string telephoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TelephoneNumber = telephoneNumber;
        }
    }
}
