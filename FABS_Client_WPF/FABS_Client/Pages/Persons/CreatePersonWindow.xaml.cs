
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

namespace FABS_Client_WPF.Pages.Persons
{
    /// <summary>
    /// Interaction logic for CreatePersonWindow.xaml
    /// </summary>
    public partial class CreatePersonWindow : Window
    {
        private PersonsGUI _parentWindow;

        public CreatePersonWindow(PersonsGUI parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreatePersonButton(object sender, RoutedEventArgs e)
        {
            PersonHelper helper = new PersonHelper();

            //Login login = new Login(emailText.Text.ToString(), "1234");
            AddressDto address = new AddressDto(
                streetnameText.Text.ToString(),
                streetNoText.Text.ToString(),
                apartmentNoText.Text.ToString(),
                zipcodeText.Text.ToString(),
                1,
                cityText.Text.ToString()
                );

            //1); // 1 in the DB is Danmark. This is hardcoded for now.
            PersonDto person = new PersonDto(
               firstNameText.Text.ToString(),
               lastNameText.Text.ToString(),
               tlfText.Text.ToString(),
                //IsAdmin = false,
                address,
               //Login = login
               emailText.Text.ToString());
            
                
        

            helper.PostPerson(person);

            _parentWindow.RefreshList();

            //var instanceOfPersonGUI = new PersonsGUI();
            //instanceOfPersonGUI.RefreshList();

            Close();
        }
    }
}
