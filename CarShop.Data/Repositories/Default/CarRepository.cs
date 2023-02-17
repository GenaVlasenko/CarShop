using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;

namespace CarShop.Data.Layer.Repositories.Default
{
    internal class CarRepository : ICarRepository
    {
        private DatabaseConnection _databaseConnection;
        public CarRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public IEnumerable<Car> GetAll()
        {
            var cars = new List<Car>();
            var pricewithsale = new List<float>();

            var sqlDataReader = _databaseConnection.Connection("Select * from Cars");

            while (sqlDataReader.Read())
            {
                cars.Add(new Car()
                {
                    Id = Convert.ToInt32(sqlDataReader[0].ToString()),
                    Picture = sqlDataReader[1].ToString(),
                    Brand = sqlDataReader[2].ToString(),
                    Model = sqlDataReader[3].ToString(),
                    Year = sqlDataReader[4].ToString(),
                    Color = sqlDataReader[5].ToString(),
                    Engine = sqlDataReader[6].ToString(),
                    TypeofCar = sqlDataReader[7].ToString(),
                    Transmission = sqlDataReader[8].ToString(),
                    Mileage = sqlDataReader[9].ToString(),
                    CarAccident = sqlDataReader[10].ToString(),
                    CarInStock = sqlDataReader[11].ToString(),
                    Price = Convert.ToSingle(sqlDataReader[12]),
                    CategoryId = Convert.ToInt32(sqlDataReader[13]),
                    SaleId = Convert.ToSingle(sqlDataReader[14]),



                });
                float price = Convert.ToSingle(sqlDataReader[12]) - Convert.ToSingle(sqlDataReader[12]) * Convert.ToSingle(sqlDataReader[14]);
                pricewithsale.Add(price); 
            }
            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();

            return cars;
        }
        public void Add(Car addcar)
        {
            _databaseConnection.Connection("Insert into Cars (Photo, Brand, Model, [Release year], " +
                 "Color, [Engine type], [Type of cab], Transmission, Mileage, [Road accident], [Availability], Price, CategoryId, OnSale) " +
                 $"Values ('{addcar.Picture}', '{addcar.Brand}', '{addcar.Model}', " +
                 $"'{addcar.Year}', '{addcar.Color}', '{addcar.Engine}', " +
                 $"'{addcar.TypeofCar}', '{addcar.Transmission}', '{addcar.Mileage}', '{addcar.CarAccident}', '{addcar.CarInStock}', " +
                 $" {addcar.Price}, {addcar.CategoryId}, {addcar.SaleId})");

            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();
        }
        public void Edit(Car editcar)
        {
            _databaseConnection.Connection($"Update Cars Set Picture '{editcar.Picture}");

            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();
        }
        public void Delete(int id)
        {
            _databaseConnection.Connection($"Delete Cars Where id = {id}");
            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();
        }


    }
}
