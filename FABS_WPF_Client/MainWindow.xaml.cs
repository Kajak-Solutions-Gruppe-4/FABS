using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FABS_WPF_Client.Model;
using RestSharp;

namespace FABS_WPF_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRestClient _client = new RestClient("https://localhost:44337/api");

        public MainWindow()
        {
            InitializeComponent();
            RefreshList();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePerson();
            RefreshList();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void CreatePerson()
        {
            Person person = new Person(
                TxtFirstName.Text,
                TxtLastName.Text,
                TxtTelNum.Text,
                int.Parse(TxtAdressID.Text),
                int.Parse(TxtLoginID.Text),
                (bool)IsAdminCheck.IsChecked
                );
            var request = new RestRequest("people");
            request.AddJsonBody(JsonSerializer.Serialize(person));
            var response = _client.Post(request);
            //Console.WriteLine(response.Content);

        }

        private void RefreshList()
        {
            var request = new RestRequest("people/", RestSharp.DataFormat.Json);
            //var response = Client.Execute<PeopleList>(request);
            var response = _client.Execute(request);
            List<Person> peopleList = JsonSerializer.Deserialize<List<Person>>(response.Content);
            //return response.Data.results;
            ListOfPeople.ItemsSource = peopleList;
        }
    }
}
