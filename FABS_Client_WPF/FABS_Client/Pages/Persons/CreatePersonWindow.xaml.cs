
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

        /// <summary>
        /// Constructor for Create Person window. Can use methods from the parent window.
        /// </summary>
        /// <param name="parentWindow"></param>
        /// <returns>A new person data entry window</returns>
        public CreatePersonWindow(PersonsGUI parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// This method creates a new Person in the database.
        /// Automatically updates the person list with the new entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Void</returns>
        private void CreatePersonButton(object sender, RoutedEventArgs e)
        {
            PersonHelper helper = new PersonHelper();

            //Login login = new Login(emailText.Text.ToString(), "1234");
            AddressDto address = new AddressDto(
                streetnameText.Text.ToString(),
                streetNoText.Text.ToString(),

                //TODO: make so apartmentNumber is null when the string is empty, instead of "" (an empty string)
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

            //Ask helper to actually post/save the person
            helper.PostPerson(person);

            //Refresh the list to reflect that the new person is saved in the database
            _parentWindow.RefreshList();

            Close();
        }
    }
}
