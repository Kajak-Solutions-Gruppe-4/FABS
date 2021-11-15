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

namespace FABS_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMember(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Persons.PersonsGUI();
        }

        private void ButtonStorage(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Items.ItemGUI();
        }

        private void EquipmentButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Checkout.CheckoutGUI();
        }

        private void BookingButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Booking.BookingGUI();
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            Main.Content = new Pages.Home.HomeGUI();
        }
    }
}
