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
            Address address = new Address(streetnameText.Text.ToString(), streetNoText.Text.ToString(),
                apartmentNoText.Text.ToString(),
                zipcodeText.Text.ToString(),
                1); // 1 in the DB is Danmark. This is hardcoded for now.
            Person person = new Person()
            {

                firstName = firstNameText.Text.ToString(),
                lastName = lastNameText.Text.ToString(),
                telephoneNumber = tlfText.Text.ToString(),
                isAdmin = false,
                addresses = address,
                login = login
            };

            helper.PostPerson(person);




            //PersonsGUI.RefreshList();

            Close();
        }
    }
}
