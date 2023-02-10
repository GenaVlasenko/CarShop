using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarShop.Data.Mocks
{
    public class DataReviews : IReviews
    {
        public IEnumerable<Reviews> AllReviews { get; set; }
        DatabaseConnection databaseConnection;
        SqlDataReader sqlDataReader;
        CheckBeforeWriting checkBeforeWriting;
        List<Reviews> reviews;
        string warning = " містить спецсимволи";
        string empty = " пусте";
        public DataReviews()
        {
            databaseConnection = new DatabaseConnection();
            AllReviews = GetReviews();
        }
        public IEnumerable<Reviews> GetReviews()
        {
            sqlDataReader = databaseConnection.Connection("Select * from Reviews");
            reviews = new List<Reviews>();
            while(sqlDataReader.Read())
            {
                reviews.Add(new Reviews()
                {
                    id = Convert.ToInt32(sqlDataReader[0]),
                    LinkOnVideo = sqlDataReader[1].ToString(),
                    Car = sqlDataReader[2].ToString(),
                    image = sqlDataReader[3].ToString()
                });
            }
            databaseConnection.connection.Close();
            return reviews;
        }
        public string AddReview(Reviews review)
        {
            checkBeforeWriting = new CheckBeforeWriting();

            if (review.LinkOnVideo != null) { }
            else
            {
                return $"Поле Посилання на Youtube" + empty;  
            }

            if (review.Car != null)
            {
                if (checkBeforeWriting.Special_Characters(review.Car)) { }
                else { return $"Поле Назва авто" + warning; }

            }
            else
            {
                return $"Поле Назва авто" + empty;
            }
            if (review.image != null) { }

            else
            {
                return $"Поле Зображення" + empty;
            }

            try
            {

                databaseConnection.Connection("Insert into Reviews (LinkOnVideo, Car, image) " +
                 $"Values ('{review.LinkOnVideo}', '{review.Car}', '{review.image}' )");
            }
            catch
            {
                databaseConnection.connection.Close();
                return "Сталася помилка при записі данних";
            }
            databaseConnection.connection.Close();
            return "Дані успішно записані";
        } 
        public string EditReview(Reviews review)
        {
            checkBeforeWriting = new CheckBeforeWriting();
            databaseConnection = new DatabaseConnection();
            if(reviews.Select(x=>x.id).Contains(review.id))
            {
                string comand = "Update Reviews Set ";
                if (review.id != 0)
                {
                    if (checkBeforeWriting.Special_Characters(Convert.ToString(review.id))) { }
                    else
                    {
                        return $"Поле Id" + warning;
                    }

                }

                if (review.LinkOnVideo != null)
                {

                    comand += $"LinkOnVideo = '{review.LinkOnVideo}', ";
                }
                else
                {
                    return $"Поле Посилання на Youtube" + empty;
                }

                if (review.Car != null)
                {
                    if (checkBeforeWriting.Special_Characters(review.Car))
                    {
                        comand += $"Car = '{review.Car}', ";
                    }
                    else
                    {
                        return $"Поле Назва авто" + warning;
                    }

                }
                else
                {
                    return $"Поле Назва авто" + empty;
                }
                if (review.image != null)
                {
                    comand += $"image = '{review.image}'";
                }
                else
                {
                    return $"{review.image}" + empty;
                }


                try
                {
                    //comand = comand.Substring(0, comand.Length - 2);
                    comand += $" Where id = {review.id}";

                    databaseConnection.Connection(comand);
                }
                catch
                {
                    databaseConnection.connection.Close();
                    return "При редагуванні сталася помилка";
                }
                databaseConnection.connection.Close();
                return "Дані успішно записані";

            }
            else
            {
                databaseConnection.connection.Close();
                return "Введенний id некорректний";
            }
           
        } 
        public string DeleteReview(int id)
        {
            checkBeforeWriting = new CheckBeforeWriting();
            if (reviews.Select(x => x.id).Contains(id))
            {
                if (id != 0)
                {

                    try
                    {
                        databaseConnection.Connection($"Delete Reviews Where id = {id}");
                    }
                    catch
                    {
                        databaseConnection.connection.Close();
                        return "Сталася помика при виделенні запису";
                    }

                }
                else
                {
                    return $"Id" + empty;
                }
                databaseConnection.connection.Close();
                return "Відгук успішно видалено";

            }
            else
            {
                databaseConnection.connection.Close();
                return "Введенний id некорректний";
            }
           
        } 
    }
}
