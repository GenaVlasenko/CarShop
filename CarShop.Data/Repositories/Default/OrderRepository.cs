using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CarShop.Data.Layer.Repositories.Default
{
    public class OrderRepository : IOrderRepository
    {   

        private DatabaseConnection _databaseConnection;
        public OrderRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public IEnumerable<Order> GetAll()
        {
            List<Order>  getallorders = new List<Order>();
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Orders");
            while(sqlDataReader.Read())
            {
                getallorders.Add(new Order()
                {
                    FirstName = sqlDataReader[1].ToString(),
                    LastName = sqlDataReader[2].ToString(),
                    Phone = sqlDataReader[3].ToString(),
                    Email = sqlDataReader[4].ToString(),
                    City = sqlDataReader[5].ToString(),
                    CarId = Convert.ToInt32(sqlDataReader[6])
                });

            }
            _databaseConnection.connection.Close();
            return getallorders;


        }
        public void Add(Order order)
        {
            _databaseConnection.Connection("Insert into Orders ([Ім'я], Фамілія, Телефон, [Email], Місто, АвтомобільId) " +
                $"Values ('{order.FirstName}', '{order.LastName}', '{order.Phone}', '{order.Email}', " +
                $"'{order.City}', {order.CarId})");
            _databaseConnection.connection.Close();

        }
        public void Delete()
        {
            _databaseConnection.Connection("Delete from Orders");
            _databaseConnection.connection.Close();
        }

        

    }
}
