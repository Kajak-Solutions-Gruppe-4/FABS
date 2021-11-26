using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using DataFormat = RestSharp.DataFormat;
using FABS_Client_WPF;
using FABS_Client_WPF.DTO;
using Newtonsoft;
using Newtonsoft.Json;
using System.Windows.Input;
using System.Xml;

namespace FABS_Client_WPF.Pages.Persons
{

    /// <summary>
    /// Interaction logic for PersonsGUI.xaml
    /// </summary>
    public partial class PersonsGUI : Page
    {
        public var editPerson { get; set; }

        public PersonsGUI()
        {
            InitializeComponent();
            RefreshList();
        }

        private void ButtonPerson(object sender, RoutedEventArgs e)
        {
            CreatePersonWindow createPersonWindow = new CreatePersonWindow(this);
            //this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            createPersonWindow.Show();
        }

        public void RefreshList()
        {
            var apiClient = new RestClient("https://localhost:44309/Api");
            // Hardcoded organisation ID for the specific client TODO: 
            //Add an universal ID to the client for use everywhwere
            var request = new RestRequest("/people?organisationId=1", DataFormat.Json);

         

            var response = apiClient.Execute(request);

            List<PersonDto> listOfPeople = JsonConvert.DeserializeObject<List<PersonDto>>(response.Content);

            Users.ItemsSource = listOfPeople;
        }

        public void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //XmlElement User = ((ListViewItem)sender).Content as XmlElement;


            editPerson = ((ListViewItem)sender).Content;

            //var usinfo = (people)person.IsSelected;
            

            UpdatePersonWindow updatePersonWindow = new UpdatePersonWindow(this.editPerson);
            //updatePersonWindow.Owner = this;
            
            
            updatePersonWindow.Show();

        }

    }
}
