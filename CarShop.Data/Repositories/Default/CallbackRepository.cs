using CarShop.Data.Layer.Common;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarShop.Data.Layer.Repositories.Default
{
    public class CallbackRepository : ICallbackRepository
    {   
        
        private DatabaseConnection _databaseConnection;
        public CallbackRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public IEnumerable<Callback> GetAll()
        {
            List<Callback> getcallbacks = new List<Callback>();
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Сallback");
            while (sqlDataReader.Read())
            {
                getcallbacks.Add(new Callback()
                {
                    Name = sqlDataReader[1].ToString(),
                    Phone = sqlDataReader[2].ToString()

                });

            }
            _databaseConnection.connection.Close();
            return getcallbacks;
        }
        public void Add(Callback callback)
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
