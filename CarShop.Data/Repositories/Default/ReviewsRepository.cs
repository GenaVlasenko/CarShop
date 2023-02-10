using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CarShop.Data.Layer.Repositories.Default
{
    public class ReviewsRepository : IReviewsRepository
    {

        private DatabaseConnection _databaseConnection;
        public ReviewsRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public IEnumerable<Reviews> GetAll()
        {
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Reviews");
            List<Reviews> reviews = new List<Reviews>();
            while(sqlDataReader.Read())
            {
                reviews.Add(new Reviews()
                {
                    Id = Convert.ToInt32(sqlDataReader[0]),
                    LinkOnVideo = sqlDataReader[1].ToString(),
                    Car = sqlDataReader[2].ToString(),
                    Image = sqlDataReader[3].ToString()
                });
            }
            _databaseConnection.connection.Close();
            return reviews;
        }
        public void Add(Reviews review)
        {
            _databaseConnection.Connection("Insert into Reviews (LinkOnVideo, Car, image) " +
              $"Values ('{review.LinkOnVideo}', '{review.Car}', '{review.Image}' )");
            _databaseConnection.connection.Close();



        } 
        public void Edit(Reviews review)
        {
            string comand = "Update Reviews Set ";

            if (review.LinkOnVideo != null)
            {
                comand += $"LinkOnVideo = '{review.LinkOnVideo}', ";
            }

            

            if (review.Image != null)
            {
                comand += $"image = '{review.Image}'";
            }

            comand += $" Where id = {review.Id}";
            _databaseConnection.Connection(comand);
            _databaseConnection.connection.Close();

        } 
        public void Delete(int id)
        {
            _databaseConnection.Connection($"Delete Reviews Where id = {id}");
            _databaseConnection.connection.Close();
            
           
        } 
    }
}
