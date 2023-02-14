using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using CarShop.Domain.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CarShop.Data.Layer.Repositories.Default
{
    public class ServiceRepository : IServiceRepository
    {
        
        private DatabaseConnection _databaseConnection;
        
        public ServiceRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
            
        }

        public IEnumerable<Service> GetAll()
        {
            List<Service> services = new List<Service>();
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Services");
            while (sqlDataReader.Read())
            {
                services.Add(new Service()
                {
                    ServiceName= sqlDataReader[1].ToString(),
                    Description = sqlDataReader[2].ToString()

                });
            }
            _databaseConnection.connection.Close();
            return services;
        }

        public void Add(Service services)
        {
            _databaseConnection.Connection("Insert into Services (ServiceName, Description) " +
              $"Values ('{services.ServiceName}', '{services.Description}')");
            _databaseConnection.connection.Close();
        }

        public void Edit(Service services)
        {
            _databaseConnection.Connection($"Update Services Set ServiceName = '{services.ServiceName}' Where id = {services.Id}");
            _databaseConnection.connection.Close();
        }

        public void Delete(int id)
        {
            _databaseConnection.Connection($"Delete Services Where id = {id}");
            _databaseConnection.connection.Close();
        }





    }
}
