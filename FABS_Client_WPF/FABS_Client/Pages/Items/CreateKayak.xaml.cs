﻿using FABS_Client_WPF.BusinessLogic;
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

        /// <summary>
        /// Logic for saving an item (kayak) to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateKayakButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
