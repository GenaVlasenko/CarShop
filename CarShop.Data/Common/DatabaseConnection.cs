using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CarShop.Data.Layer.Common
{
    public class DatabaseConnection
    {
        private IConfiguration _configuration { get; set; }

        private SqlCommand _command;

        public SqlConnection connection { get; set; }
        public SqlDataReader reader { get; set; }

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlDataReader Connection(string comand)
        {
            string connectionString = _configuration.GetConnectionString("Default");

            connection = new SqlConnection(connectionString);
            connection.Open();
            _command = new SqlCommand(comand, connection);
            reader = _command.ExecuteReader();
            return reader;

        }
    }
}
