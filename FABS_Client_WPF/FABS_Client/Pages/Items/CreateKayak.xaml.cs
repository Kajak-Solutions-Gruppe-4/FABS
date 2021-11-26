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
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreatKayakButton(object sender, RoutedEventArgs e)
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
                ) ;

            //item
            ItemDto item = new ItemDto(
                location,
                itemType
                );



            helper.PostItem(item);

            _parentWindow.RefreshList();

            Close();
        }

        public void SetLocationList()
        {

        }
    }
}
