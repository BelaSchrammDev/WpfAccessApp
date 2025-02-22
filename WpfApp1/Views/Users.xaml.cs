using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Data;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaktionslogik für Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            ListClear();
            SetListColumnsToUsers();
            ShowUsers();
        }
        private void ListClear()
        {
            dataGridUsers.Items.Clear();
        }
        private void SetListColumnsToUsers()
        {
            dataGridUsers.Columns.Clear();
            dataGridUsers.Columns.Add(new DataGridTextColumn() { Header = "ID", Binding = new Binding("Id"), Width = 50 });
            dataGridUsers.Columns.Add(new DataGridTextColumn() { Header = "UserName", Binding = new Binding("Username"), Width = 250 });
            dataGridUsers.Columns.Add(new DataGridTextColumn() { Header = "EMail", Binding = new Binding("Useremail"), Width = 300 });
        }
        private void ShowUsers()
        {
            var dbHelper = new AccessDatabaseHelper();
            var users = dbHelper.GetWPFUsers();
            foreach (var user in users)
            {
                dataGridUsers.Items.Add(user);
            }
        }
        private void ListUsers(object sender, RoutedEventArgs e)
        {
            ListClear();
            SetListColumnsToUsers();
            ShowUsers();
        }
    }
}
