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

namespace FABS_Client.Pages.Items
{
    /// <summary>
    /// Interaction logic for ItemGUI.xaml
    /// </summary>
    public partial class ItemGUI : Page
    {
        public ItemGUI()
        {
            InitializeComponent();
        }

        private void CreateKayakButton(object sender, RoutedEventArgs e)
        {
            CreateKayak createKayak = new CreateKayak();
            //this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            createKayak.Show();
        }
    }
}
