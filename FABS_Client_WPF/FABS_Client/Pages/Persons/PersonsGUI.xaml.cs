using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using RestSharp;
using DataFormat = RestSharp.DataFormat;
using FABS_Client_WPF;
using FABS_Client_WPF.DTO;
using Newtonsoft;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Windows.Data;
using System;

namespace FABS_Client_WPF.Pages.Persons
{
    /// <summary>
    /// Interaction logic for PersonsGUI.xaml
    /// </summary>
    public partial class PersonsGUI : Page
    {
        public PersonsGUI()
        {
            InitializeComponent();
            RefreshList();
        }

        private void ButtonPerson(object sender, RoutedEventArgs e)
        {
            CreatePersonWindow createPersonWindow = new CreatePersonWindow(this);
            //this.Visibility = Visibility.Hidden //Hides Main window while usng second window
            createPersonWindow.Show();
        }

        public void RefreshList()
        {
            var apiClient = new RestClient("https://localhost:44309/Api");
            // Hardcoded organisation ID for the specific client TODO: 
            //Add an universal ID to the client for use everywhwere
            var request = new RestRequest("/people?organisationId=1", DataFormat.Json);



            var response = apiClient.Execute(request);

            List<PersonDto> listOfPeople = JsonConvert.DeserializeObject<List<PersonDto>>(response.Content);

            Users.ItemsSource = listOfPeople;
        }

        //sorting by clicking on header

        private GridViewColumnHeader lastHeaderClicked = null;
        private ListSortDirection lastDirection = ListSortDirection.Ascending;


        private void OnHeaderClick(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    //if (direction == ListSortDirection.Ascending)
                    //{
                    //    headerClicked.Column.HeaderTemplate =
                    //      Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    //}
                    //else
                    //{
                    //    headerClicked.Column.HeaderTemplate =
                    //      Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    //}

                    // Remove arrow from previously sorted header
                    //if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    //{
                    //    _lastHeaderClicked.Column.HeaderTemplate = null;
                    //}

                    lastHeaderClicked = headerClicked;
                    lastDirection = direction;

                    void Sort(string sortBy, ListSortDirection direction)
                    {
                        ICollectionView dataView =
                          CollectionViewSource.GetDefaultView(Users.ItemsSource);

                        dataView.SortDescriptions.Clear();
                        SortDescription sd = new SortDescription(sortBy, direction);
                        dataView.SortDescriptions.Add(sd);
                        dataView.Refresh();
                    }
                }
            }

        }

        //private bool UserFilter(object item)
        //{
        //    if (String.IsNullOrEmpty(TxtFilter.Text))
        //        return true;
        //    else
        //        return ((item as PersonDto).FirstName.IndexOf(TxtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        //}

        //private void TxtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(Users.ItemsSource).Refresh();
        //}



    }
}
