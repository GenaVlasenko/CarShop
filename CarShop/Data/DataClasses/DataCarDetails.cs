using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CarShop.Data.Mocks
{
    public class DataCarDetails: ICarsDetails
    {
        public IEnumerable<CarDetails> AllCarsDetails { get; set; }
  

        DatabaseConnection databaseConnection;
        SqlDataReader sqlDataReader;
        public static List<int> pricewithsale;
        List<CarDetails> allcardetails;

        public DataCarDetails()
        {
            databaseConnection = new DatabaseConnection();
            AllCarsDetails = GetAllCarDetails();


        }
        public IEnumerable<CarDetails> GetAllCarDetails()
        {
            allcardetails = new List<CarDetails>();
            sqlDataReader = databaseConnection.Connection("Select * From CarDetails");
            while(sqlDataReader.Read())
            {
                allcardetails.Add(new CarDetails()
                {
                    
                    //main_photo = sqlDataReader[1].ToString(),
                    video = sqlDataReader[1].ToString(),
                    first_photo = sqlDataReader[2].ToString(),
                    second_photo = sqlDataReader[3].ToString(),
                    third_photo = sqlDataReader[4].ToString(),
                    four_photo = sqlDataReader[5].ToString(),
                    car_id = Convert.ToInt32(sqlDataReader[6])

                });
            }
            return allcardetails;
        }
        public void AddCarsDetails(CarDetails carsdetails)
        {
            databaseConnection = new DatabaseConnection();
            databaseConnection.Connection("Insert into CarsDetails (main_photo, video, first_photo, second_photo, " +
                 "third_photo, four_photo, car_id) " +
                 $"Values ('{carsdetails.video}', '{carsdetails.first_photo}', " +
                 $"'{carsdetails.second_photo}', '{carsdetails.third_photo}', '{carsdetails.four_photo}', " +
                 $"{carsdetails.car_id})");
        }
    }
}
