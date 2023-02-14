using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CarShop.Data.Layer.Repositories.Default
{
    public class ReviewRepository : IReviewRepository
    {

        private DatabaseConnection _databaseConnection;
        public ReviewRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public IEnumerable<Review> GetAll()
        {
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Reviews");
            List<Review> reviews = new List<Review>();
            while(sqlDataReader.Read())
            {
                reviews.Add(new Review()
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
        public void Add(Review review)
        {
            _databaseConnection.Connection("Insert into Reviews (LinkOnVideo, Car, image) " +
              $"Values ('{review.LinkOnVideo}', '{review.Car}', '{review.Image}' )");
            _databaseConnection.connection.Close();



        } 
        public void Edit(Review review)
        {
            
            _databaseConnection.Connection($"Update Reviews Set LinkOnVideo = '{review.LinkOnVideo}' Where id = {review.Id}");
            _databaseConnection.connection.Close();

        } 
        public void Delete(int id)
        {
            _databaseConnection.Connection($"Delete Reviews Where id = {id}");
            _databaseConnection.connection.Close();
            
           
        } 
    }
}
