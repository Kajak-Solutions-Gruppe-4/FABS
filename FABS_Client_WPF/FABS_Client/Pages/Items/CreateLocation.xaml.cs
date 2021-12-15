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
using RestSharp;
using DataFormat = RestSharp.DataFormat;
using FABS_Client_WPF.BusinessLogic;
using FABS_Client_WPF.DTO;
using System.Globalization;

namespace FABS_Client_WPF.Pages.Items
{
    /// <summary>
    /// Interaction logic for CreateLocation.xaml
    /// </summary>
    public partial class CreateLocation : Window
    {
        private ItemGUI _parentWindow;
        public CreateLocation(ItemGUI parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //TODO Implimentation
        private void CreateButton(object sender, RoutedEventArgs e)
        {
            _parentWindow.RefreshList();
            Close();
        }

        private void LoadWarehouseComboBox()
        {
            //To Do Populate Combo with right data or api call
            //warehouseDropDown.ItemsSource = new List<string> { "Varehus 1 1", "Varehus 2" };

            var apiClient = new RestClient("https://localhost:44309/Api");
            var request = new RestRequest("/Warehouses?organisationId=1", DataFormat.Json);

            var response = apiClient.Execute(request);

            List<WarehouseDto> listOfWarehouses = JsonConvert.DeserializeObject<List<WarehouseDto>>(response.Content);

            warehouseDropDown.ItemsSource = listOfWarehouses;
        }

        private void LoadPersonComboBox()
        {
            //To Do Populate Combo with right data or api call
            //personDropDown.ItemsSource = new List<string> { "John", "Peter" };

            var apiClient = new RestClient("https://localhost:44309/Api");
            var request = new RestRequest("/People?organisationId=1", DataFormat.Json);

            var response = apiClient.Execute(request);

            List<PersonDto> listOfPeople = JsonConvert.DeserializeObject<List<PersonDto>>(response.Content);

            personDropDown.ItemsSource = listOfPeople;
        }


    }
}
