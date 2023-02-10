using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CarShop.Data.Layer.Repositories.Default
{
    public class CompanyServiceRepository : ICompanyServicesRepository
    {
        
        private DatabaseConnection _databaseConnection;
        
        public CompanyServiceRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
            
        }

        public void Add(CompanyService services)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(CompanyService services)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyService> GetAll()
        {
            List<CompanyService> services = new List<CompanyService>();
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Services");
            while (sqlDataReader.Read())
            {
                services.Add(new CompanyService()
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
            _databaseConnection.connection.Close();
            return services;
        }

        

        
    }
}
