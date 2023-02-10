using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarShop.Data.Mocks
{
    public class DataOrder : IOrders
    {   
        public IEnumerable<Order> GetOrders { get; set; }
        public IEnumerable<CallBack> GetCallbacks { get; set; }
        CheckBeforeWriting checkBefore;
        DatabaseConnection databaseConnection;
        SqlDataReader sqlDataReader;
        string warning = " поле містить спецсимволи";
        public DataOrder()
        {
            databaseConnection = new DatabaseConnection();
            GetOrders = GetAllOrders();
            GetCallbacks = GetAllCallbacks();
        }
        public IEnumerable<Order> GetAllOrders()
        {
            List<Order>  getallorders = new List<Order>();
            sqlDataReader = databaseConnection.Connection("Select * from Orders");
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
            databaseConnection.connection.Close();
            return getallorders;


        }
        public string Order(Order order)
        {
            checkBefore = new CheckBeforeWriting();

            if (order.FirstName != null)
            {
                if (checkBefore.Special_Characters(order.FirstName)) { }
                else { return $"{ order.FirstName}" + warning; }

            }
            else { return $"Некоректно заповнене поле Ім'я"; }

            if (order.LastName != null)
            {
                if (checkBefore.Special_Characters(order.LastName)) { }
                else { return $"{ order.LastName}" + warning; }

            }
            else { return $"Некоректно заповнене поле Прізвище"; }

            if (order.Phone != null) 
            {
                
            }

            else { return $"Некоректно заповнене поле телефон"; }


            if (order.Email != null && order.Email.Contains("@") && order.Email.Contains(".")) { }

            else { return $"Некоректно заповнене поле Email"; }

            if (order.City != null)
            {
                if (checkBefore.Special_Characters(order.City)) { }
                else { return $"{ order.City}" + warning; }

            }
            else { return $"Некоректно заповнене поле Місто"; }

            if (order.CarId != 0)
            {
                if (checkBefore.Special_Characters(Convert.ToString(order.CarId))) { }
                else { return $"{ order.CarId}" + warning; }

            }
            else { return $"Некоректно заповнене поле Код автомобіля"; }

            try
            {
                databaseConnection.Connection("Insert into Orders ([Ім'я], Фамілія, Телефон, [Email], Місто, АвтомобільId) " +
                $"Values ('{order.FirstName}', '{order.LastName}', '{order.Phone}', '{order.Email}', " +
                $"'{order.City}', {order.CarId})");

            }
            catch
            {
                databaseConnection.connection.Close();
                return "При формуванні заказу виникла помилка, можливо вы некоректно заповнили поля вводу";

            }
            databaseConnection.connection.Close();
            return "Операція пройшла успішно";

        }
        public string DeleteOrders()
        {
            try
            {
                databaseConnection.Connection("Delete from Orders");
            }
            catch
            {
                databaseConnection.connection.Close();
                return "Помилка при видаленні замовлень";
            }
            databaseConnection.connection.Close();
            return "Всі замовлення успішно видалені";

            
        }
        public IEnumerable<CallBack> GetAllCallbacks()
        {
            List<CallBack> getcallbacks = new List<CallBack>();
            sqlDataReader = databaseConnection.Connection("Select * from Сallback");
            while (sqlDataReader.Read())
            {
                getcallbacks.Add(new CallBack()
                {
                    name = sqlDataReader[1].ToString(),
                    phone = sqlDataReader[2].ToString()
                    
                });

            }
            databaseConnection.connection.Close();
            return getcallbacks;
        }
        public string AddCallback(CallBack callback)
        {
            checkBefore = new CheckBeforeWriting();
            if (checkBefore.Special_Characters(callback.name) || callback.phone.Length > 17) { }
            else { return $"Поле Ім'я" + warning; }
            if (!callback.phone.Any(c => char.IsLetter(c))) { }
            else
            {
                return $"Поле Телефон містить букви, заповніть будь ласка корректно";
            }
            try
            {
                databaseConnection.Connection("Insert into Сallback (Name, Phone) " +
                $"Values('{callback.name}', '{callback.phone}')");



            }
            catch
            {
                databaseConnection.connection.Close();
                return "При формуванні заказу виникла помилка, можливо вы некоректно заповнили поля вводу";

            }
            databaseConnection.connection.Close();
            return "Дякую, ми з вами звяжемось протягом 5 хвилин";

        }
        public string DeleteAllCallbacks()
        {
            try
            {
                databaseConnection.Connection("Delete from Сallback");
            }
            catch
            {
                databaseConnection.connection.Close();
                return "Помилка при видаленні замовлень";
            }
            databaseConnection.connection.Close();
            return "Всі зворотні виклики успішно видалені";

        }

    }
}
