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
using FABS_Client_WPF.BusinessLogic;
using FABS_Client_WPF.DTO;



namespace FABS_Client_WPF.Pages.Persons
{
    /// <summary>
    /// Interaction logic for UpdatePersonWindow.xaml
    /// </summary>
    public partial class UpdatePersonWindow : Window
    {
        private PersonsGUI _parentWindow;

        public UpdatePersonWindow(PersonsGUI parentWindow, object Person)
        {
            _parentWindow = parentWindow;
            InitializeComponent();

            string FirstName = ((FABS_Client_WPF.DTO.PersonDto)Person).FirstName;
            string LastName = ((FABS_Client_WPF.DTO.PersonDto)Person).LastName;
            string Email = ((FABS_Client_WPF.DTO.PersonDto)Person).Email;
            string Phone = ((FABS_Client_WPF.DTO.PersonDto)Person).TelephoneNumber;
            string Street = ((FABS_Client_WPF.DTO.PersonDto)Person).Address.StreetName;
            string SNum = ((FABS_Client_WPF.DTO.PersonDto)Person).Address.StreetNumber;
            string AptNum = ((FABS_Client_WPF.DTO.PersonDto)Person).Address.ApartmentNumber;
            string City = ((FABS_Client_WPF.DTO.PersonDto)Person).Address.City;
            string Zipcode = ((FABS_Client_WPF.DTO.PersonDto)Person).Address.Zipcode;


            firstNameText.Text = FirstName;
            lastNameText.Text = LastName;
            emailText.Text = Email;
            tlfText.Text = Phone;
            streetnameText.Text = Street;
            streetNoText.Text = SNum;
            apartmentNoText.Text = AptNum;
            cityText.Text = City;
            zipcodeText.Text = Zipcode;

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdatePersonButton(object sender, RoutedEventArgs e)
        {
            PersonHelper helper = new PersonHelper();

            //Login login = new Login(emailText.Text.ToString(), "1234");
            AddressDto address = new AddressDto(
                streetnameText.Text.ToString(),
                streetNoText.Text.ToString(),

                //TODO: make so arpartmentNumber is null when the string is empty, instead of "" (an empty string)
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




            helper.PutPerson(person);

            _parentWindow.RefreshList();

            Close();
        }

        private void DeletePersonButton(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Sletning af medlem er permanent. Er du sikker?", "Advarsel!", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Så sletter vi den!", "Advarsel!");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Så sletter vi den ikke!", "Alt er OK");
                    break;

            }
        }

        private void NewBooking(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
