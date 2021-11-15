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

namespace FABS_Client.Pages.Persons
{
    /// <summary>
    /// Interaction logic for PersonsGUI.xaml
    /// </summary>
    public partial class PersonsGUI : Page
    {
        public PersonsGUI()
        {
            InitializeComponent();
        }

        private void ButtonPerson(object sender, RoutedEventArgs e)
        {
            CreatePersonWindow createPersonWindow = new CreatePersonWindow();
            //this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            createPersonWindow.Show();
        }
    }
}
