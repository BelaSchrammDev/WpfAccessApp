using Dapper;
using System.Data.OleDb;
using WpfApp1.Data.Entitys;

namespace WpfApp1.Data
{
    public class AccessDatabaseHelper
    {
        private readonly string _connectionString;

        public AccessDatabaseHelper()
        {
            _connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Bela\\Documents\\wiesecker1.accdb;Persist Security Info=False;";
        }

        public List<Vehicle> GetVehicles()
        {
            using (var connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Vehicle>("SELECT v.id, v.description, v.purchased, vt.type AS vehicletype FROM Vehicles AS v INNER JOIN vehicletypes AS vt ON v.vehicletype_id = vt.id").AsList();
            }
        }

        public List<WPFUser> GetWPFUsers()
        {
            using (var connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<WPFUser>("SELECT * FROM users").AsList();
            }
        }

        public void InsertVehicle(string description, DateTime purchased, int vehicleTypeId)
        {
            using (var connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Vehicles (Description, Purchased, Vehicletype_Id) VALUES (@Description, @Purchased, @VehicleTypeId)";
                connection.Execute(query, new { Description = description, Purchased = purchased.ToString("yyyy-MM-dd"), VehicleTypeId = vehicleTypeId });
            }
        }
    }
}
