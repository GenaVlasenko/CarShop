using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;


namespace CarShop.Data.Layer.Repositories.Default
{
    public class CarDetailRepository: ICarDetailRepository
    {
        private DatabaseConnection _databaseConnection;
        public CarDetailRepository(DatabaseConnection databaseConnection)
        {
             _databaseConnection = databaseConnection;
        }
        public IEnumerable<CarDetail> GetAll()
        {
            List<CarDetail> allcardetails = new List<CarDetail>();
            var sqlDataReader = _databaseConnection.Connection("Select * From CarDetails");
            while (sqlDataReader.Read())
            {
                allcardetails.Add(new CarDetail()
                {

                    //main_photo = sqlDataReader[1].ToString(),
                    Video = sqlDataReader[1].ToString(),
                    First_photo = sqlDataReader[2].ToString(),
                    Second_photo = sqlDataReader[3].ToString(),
                    Third_photo = sqlDataReader[4].ToString(),
                    Four_photo = sqlDataReader[5].ToString(),
                    Car_id = Convert.ToInt32(sqlDataReader[6])

                });
            }
            return allcardetails;

        }
        public void Add(CarDetail carsdetails)
        {
            _databaseConnection.Connection("Insert into CarsDetails (main_photo, video, first_photo, second_photo, " +
                 "third_photo, four_photo, car_id) " +
                 $"Values ('{carsdetails.Video}', '{carsdetails.First_photo}', " +
                 $"'{carsdetails.Second_photo}', '{carsdetails.Third_photo}', '{carsdetails.Four_photo}', " +
                 $"{carsdetails.Car_id})");
        }
    }
}
