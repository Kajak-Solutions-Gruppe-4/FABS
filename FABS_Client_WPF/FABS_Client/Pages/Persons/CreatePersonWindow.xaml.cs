﻿using System;
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
            Close();
        }
    }
}