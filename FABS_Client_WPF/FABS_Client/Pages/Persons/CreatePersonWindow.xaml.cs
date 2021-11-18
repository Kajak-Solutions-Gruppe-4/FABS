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
using FABS_Client_WPF.BusinessLogic;

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
            PersonHelper helper = new PersonHelper();

            Login login = new Login(emailText.Text.ToString(), "1234");
            Person person = new Person()
            {

                firstName = firstNameText.Text.ToString(),
                lastName = lastNameText.Text.ToString(), 
                login,                
                telephoneNumber = tlfText.Text.ToString(),
                street = streetnameText.Text.ToString(),
                number = streetNoText.Text.ToString(),
                apartment = apartmentNoText.Text.ToString(),
                city = cityText.Text.ToString(),
                zipCode = zipcodeText.Text.ToString()

            };




     

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
