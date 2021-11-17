using FABS_Client_WPF.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Newtonsoft.Json;
using DataFormat = RestSharp.DataFormat;

namespace FABS_Client_WPF.Pages.Persons
{
    /// <summary>
    /// Interaction logic for CreatePersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        public CreatePersonWindow()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreatePersonButton(object sender, RoutedEventArgs e)
        {
            var firstName = firstNameText.Text.ToString();
            var lastName = lastNameText.Text.ToString();
            var email = emailText.Text.ToString();
            var telephoneNumber = tlfText.Text.ToString();
            var street = streetnameText.Text.ToString();
            var number = streetNoText.Text.ToString();
            var apartment = apartmentNoText.Text.ToString();
            var city = cityText.Text.ToString();
            var zipCode = zipcodeText.Text.ToString();

            ZipcodeCountryCity zip = new ZipcodeCountryCity(zipCode, "Danmark", city);
            Login login = new Login(email, "1234");
            Address address = new Address(street, number, apartment, zip);
            Person newPerson = new Person(firstName, lastName, telephoneNumber, false, address, login);

            string jsonPerson = JsonConvert.SerializeObject(newPerson);


            var apiClient = new RestClient("https://localhost:44309/Api");

            var request = new RestRequest("people");
            
            request.AddJsonBody(newPerson);

            var response = apiClient.Post(request);

            var returnConfirmation = JsonConvert.DeserializeObject(response.Content);

            //PersonsGUI.RefreshList();

            Close();
        }
    }
}
