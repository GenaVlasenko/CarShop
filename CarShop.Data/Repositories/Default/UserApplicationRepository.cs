using CarShop.Data.Layer.Common;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarShop.Data.Layer.Repositories.Default
{
    public class UserApplicationRepository : IUserApplicationRepository
    {   
        
        private DatabaseConnection _databaseConnection;
        public UserApplicationRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public IEnumerable<UserApplication> GetAll()
        {
            List<UserApplication> getcallbacks = new List<UserApplication>();
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Сallback");
            while (sqlDataReader.Read())
            {
                getcallbacks.Add(new UserApplication()
                {
                    Name = sqlDataReader[1].ToString(),
                    Phone = sqlDataReader[2].ToString()

                });

            }
            _databaseConnection.connection.Close();
            return getcallbacks;
        }
        public void Add(UserApplication callback)
        {

            _databaseConnection.Connection("Insert into Сallback (Name, Phone) " +
                $"Values('{callback.Name}', '{callback.Phone}')");
            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();


        }
        public void Delete()
        {
            _databaseConnection.Connection("Delete from Сallback");
            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();
            
        }
    }
}
