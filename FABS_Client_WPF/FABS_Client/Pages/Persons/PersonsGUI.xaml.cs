using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using DataFormat = RestSharp.DataFormat;
using FABS_Client_WPF;
using FABS_Client_WPF.Model;
using Newtonsoft;
using Newtonsoft.Json;

namespace FABS_Client_WPF.Pages.Persons
{
    /// <summary>
    /// Interaction logic for PersonsGUI.xaml
    /// </summary>
    public partial class PersonsGUI : Page
    {
        public PersonsGUI()
        {
            InitializeComponent();
            RefreshList();
        }

        private void ButtonPerson(object sender, RoutedEventArgs e)
        {
            CreatePersonWindow createPersonWindow = new CreatePersonWindow();
            //this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            createPersonWindow.Show();
        }

        public void RefreshList()
        {
            var apiClient = new RestClient("https://localhost:44309/Api");

            var request = new RestRequest("/people", DataFormat.Json);

            var response = apiClient.Execute(request);

            List<Person> listOfPeople = JsonConvert.DeserializeObject<List<Person>>(response.Content);

            Users.ItemsSource = listOfPeople;
        }
    }
}
