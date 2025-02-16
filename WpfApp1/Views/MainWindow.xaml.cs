using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Data;
using WpfApp1.Views;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListClear()
        {
            dataGridUsers.Items.Clear();
        }

        private void SetListColumnsToVecicles()
        {
            dataGridUsers.Columns.Clear();
            dataGridUsers.Columns.Add(new DataGridTextColumn() { Header = "ID", Binding = new Binding("Id"), Width = 50 });
            dataGridUsers.Columns.Add(new DataGridTextColumn() { Header = "VehicleType", Binding = new Binding("VehicleType"), Width = 100 });
            dataGridUsers.Columns.Add(new DataGridTextColumn() { Header = "Description", Binding = new Binding("Description"), Width = 200 });
            dataGridUsers.Columns.Add(new DataGridTextColumn() { Header = "DateOfPurchase", Binding = new Binding("Purchased"), Width = 200 });
        }

        private void ListVehicles(object sender, RoutedEventArgs e)
        {
            ListClear();
            SetListColumnsToVecicles();

            var dbHelper = new AccessDatabaseHelper();
            var vehicles = dbHelper.GetVehicles();
            foreach (var vehicle in vehicles)
            {
                dataGridUsers.Items.Add(vehicle);
            }
        }

        private void OpenUserWindow(object sender, RoutedEventArgs e)
        {
            Users users = new();
            users.ShowDialog();
        }

        private void InsertVehicle(object sender, RoutedEventArgs e)
        {
            var dbHelper = new AccessDatabaseHelper();
            dbHelper.InsertVehicle("New Gerät 1", System.DateTime.Now, 1);
            dbHelper.InsertVehicle("New Gerät 2", System.DateTime.Now, 3);
            dbHelper.InsertVehicle("New Gerät 3", System.DateTime.Now, 4);
        }
    }
}