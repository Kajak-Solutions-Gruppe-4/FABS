using FABS_Client_WPF.DTO;
using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataFormat = RestSharp.DataFormat;

namespace FABS_Client_WPF.Pages.Items
{
    /// <summary>
    /// Interaction logic for ItemGUI.xaml
    /// </summary>
    public partial class ItemGUI : Page
    {
        public ItemGUI()
        {
            InitializeComponent();
            RefreshList();
        }

        /// <summary>
        /// This method creates a window for data entry of a new item.
        /// It also sends the main window along so the list can refresh automatically.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Void</returns>
        private void CreateKayakButton(object sender, RoutedEventArgs e)
        {
            CreateKayak createKayak = new CreateKayak(this);
            //this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            createKayak.Show();
        }

        /// <summary>
        /// Creates a REST client for retrieving items from the database.
        /// </summary>
        /// <returns>Returns a list of all items for the organisation.</returns>
        public void RefreshList()
        {
            var apiClient = new RestClient("https://localhost:44309/Api");
            var request = new RestRequest("/items?organisationId=1", DataFormat.Json);

            var response = apiClient.Execute(request);

            List<ItemDto> listOfItems = JsonConvert.DeserializeObject<List<ItemDto>>(response.Content); 

            Kayaks.ItemsSource = listOfItems;
        }
    }
}
