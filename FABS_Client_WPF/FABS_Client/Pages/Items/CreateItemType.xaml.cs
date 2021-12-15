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

namespace FABS_Client_WPF.Pages.Items
{
    /// <summary>
    /// Interaction logic for CreateItemType.xaml
    /// </summary>
    public partial class CreateItemType : Window
    {
        private ItemGUI _parentWindow;
        public CreateItemType(ItemGUI parentWindow)
        {
            _parentWindow = parentWindow;
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //TODO Implimentation
        private void CreateButton(object sender, RoutedEventArgs e)
        {
            _parentWindow.RefreshList();
            Close();
        }
    }
}
