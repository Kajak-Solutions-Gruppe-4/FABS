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
       // private PersonsGUI _parentWindow;
        public UpdatePersonWindow()
        {
           // _parentWindow = parentWindow;
            InitializeComponent();

           // Person =;
          

         //firstNameText.Text = person.Firstname;

        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreatePersonButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
