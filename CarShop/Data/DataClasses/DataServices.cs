using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CarShop.Data.Mocks
{
    public class DataServices : IServices
    {
        public IEnumerable<Services> AllServices { get; set; }
        DatabaseConnection databaseConnection;
        SqlDataReader sqlDataReader;
        public DataServices()
        {
            databaseConnection = new DatabaseConnection();
            AllServices = GetAllServices();
        }
        public IEnumerable<Services> GetAllServices()
        {
            List<Services> services = new List<Services>();
            sqlDataReader = databaseConnection.Connection("Select * from Services");
            while(sqlDataReader.Read())
            {
                services.Add(new Services()
                {
                    Auction = sqlDataReader[1].ToString(),
                    DeliveryUSA = sqlDataReader[2].ToString(),
                    DeliveryUSA_Ukraine = sqlDataReader[3].ToString(),
                    Customs_Clearance = sqlDataReader[4].ToString(),
                    Delivery_InCity = sqlDataReader[5].ToString(),
                    Repairy = sqlDataReader[6].ToString(),
                    Registration = sqlDataReader[7].ToString(),
                    Detailing = sqlDataReader[8].ToString(),

                });
            }
            databaseConnection.connection.Close();
            return services;
        }

        
    }
}
