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
﻿using RestSharp;
using DataFormat = RestSharp.DataFormat;
using FABS_Client_WPF.BusinessLogic;
using FABS_Client_WPF.DTO;
using System.Globalization;

namespace FABS_Client_WPF.Pages.Items
{
    /// <summary>
    /// Interaction logic for CreateKayak.xaml
    /// </summary>
    public partial class CreateKayak : Window
    {
        private ItemGUI _parentWindow;
        public CreateKayak(ItemGUI parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
            LoadItemTypeComboBox();
            LoadWarehouseComboBox();
            LoadLocationComboBox();
            LocationVisability();

        }

        private void ItemTypeButton(object sender, RoutedEventArgs e)
        {
            //CreateKayak createKayak = new CreateKayak(this);
            ////this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            //createKayak.Show();
            throw new NotImplementedException();
        }

        private void LocationButton(object sender, RoutedEventArgs e)
        {
            //CreateLocation createLocation = new CreateLocation(this);
            ////this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            //createLocation.Show();
            throw new NotImplementedException();
        }

        private void WarehouseButton(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Logic for saving an item (kayak) to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton(object sender, RoutedEventArgs e)
        {
            ItemHelper helper = new ItemHelper();

            //KayakType
            KayakTypeDto kayakType = new KayakTypeDto(
                itemTypeDecriptionText.Text.ToString(),
                Int32.Parse(kayakWeightText.Text.ToString()),
                Decimal.Parse(kayakLengthText.Text.ToString()),
                Int32.Parse(kayakPersonCapacityText.Text.ToString())
                );

            //ItemType
            ItemTypeDto itemType = new ItemTypeDto(
                itemTypeDropDown.Text.ToString(),
                kayakType
                );

            //location
            LocationDto location = new LocationDto(
                locationDropDown.Text.ToString()
                );

            ////warehouse
            //WarehouseDto warehouse = new WarehouseDto(
            //    warehouseDropDown.Text.ToString()
            //    );

            //Item
            ItemDto item = new ItemDto(
                location,
                itemType
                );

            ////item

            //if (warehouseDropDown != null)
            //{
            //    ItemDto item = new ItemDto(
            //        location,
            //        itemType,
            //        warehouse
            //        );
            //    helper.PostItem(item);
            //}
            //else
            //{
            //    ItemDto item = new ItemDto(
            //        location,
            //        itemType
            //        );
            //    helper.PostItem(item);
            //}

            _parentWindow.RefreshList();

            Close();
        }

        private void LoadItemTypeComboBox()
        {
            //To Do Populate Combo with right data or api call
            //itemTypeDropDown.ItemsSource = new List<string> { "Kayaks" };
            //itemTypeDropDown.ItemsSource = ItemTypeHelper.GetAllItems(1);

            var apiClient = new RestClient("https://localhost:44309/Api");
            var request = new RestRequest("/itemTypes?organisationId=1", DataFormat.Json);

            var response = apiClient.Execute(request);

            List<ItemTypeDto> listOfItemTypes = JsonConvert.DeserializeObject<List<ItemTypeDto>>(response.Content);

            itemTypeDropDown.ItemsSource = listOfItemTypes;
        }

        private void LoadWarehouseComboBox()
        {
            //To Do Populate Combo with right data or api call
            //locationDropDown.ItemsSource = new List<string> { "Plads 1", "Plads 2" };

            var apiClient = new RestClient("https://localhost:44309/Api");
            var request = new RestRequest("/Warehouses?organisationId=1", DataFormat.Json);

            var response = apiClient.Execute(request);

            List<WarehouseDto> listOfWarehouses = JsonConvert.DeserializeObject<List<WarehouseDto>>(response.Content);

            warehouseDropDown.ItemsSource = listOfWarehouses;
        }

        private void LoadLocationComboBox()
        {
            //To Do Populate Combo with right data or api call
            //locationDropDown.ItemsSource = new List<string> { "Plads 1", "Plads 2" };

            var apiClient = new RestClient("https://localhost:44309/Api");
            var request = new RestRequest("/Locations?organisationId=1", DataFormat.Json);

            var response = apiClient.Execute(request);

            List<LocationDto> listOfLocations = JsonConvert.DeserializeObject<List<LocationDto>>(response.Content);
            locationDropDown.ItemsSource = listOfLocations;
        }

        public void SetLocationList()
        {

        }

        private void itemTypeDropDown_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var content = itemTypeDropDown.SelectedItem;
            kayakLengthText.Text = (string)content;
        }

        private void CountAddButton(object sender, RoutedEventArgs e)
        {
            int textbox;
            int result;

            textbox = Convert.ToInt32(AmountText.Text);
            result = textbox + 1;
            AmountText.Text = Convert.ToString(result);

        }

        private void CountSubtractButton(object sender, RoutedEventArgs e)
        {
            int textbox;
            int result;

            textbox = Convert.ToInt32(AmountText.Text);
            result = textbox - 1;
            AmountText.Text = Convert.ToString(result);
        }

        //TODO Hide Elemens until selected
        private void LocationVisability()
        {
            //locationDropDown_FocusableChanged
            string l = Convert.ToString(locationDropDown);

            if (string.IsNullOrEmpty(l))
            {
                LocationDecriptionHeader.Visibility = Visibility.Visible;
                LocationDecriptionText.Visibility = Visibility.Visible;
            }
            else
            {
                LocationDecriptionHeader.Visibility = Visibility.Hidden;
                LocationDecriptionText.Visibility = Visibility.Hidden;
            }
        }

        private void locationDropDown_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LocationVisability();
        }

        private void locationDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LocationVisability();
        }
    }
}
