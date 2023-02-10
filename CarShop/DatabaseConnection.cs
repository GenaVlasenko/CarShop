using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace CarShop
{
    public class DatabaseConnection
    {
        IConfiguration AppConfiguration { get; set; }
        public SqlConnection connection { get; set; }
        public SqlDataReader reader { get; set; }

        SqlCommand command;
       
        string connectionString = string.Empty;
        public DatabaseConnection()
        {
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Path.GetDirectoryName(location));
            builder.AddXmlFile("Web.config");
            AppConfiguration = builder.Build();
            connectionString = AppConfiguration.GetSection("connectionStrings:add:Default:connectionString").Value;
        }


        public SqlDataReader Connection(string comand)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand(comand, connection);
            reader = command.ExecuteReader();
            return reader;

        }
    }
}
