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
            var pricewithsale = new List<int>();

            var sqlDataReader = _databaseConnection.Connection("Select *, Case " +
                " When OnSale = 1 Then Ціна * 1  " +
                "When OnSale = 2 Then Ціна - Ціна * 0.1" +
                "When OnSale = 3 Then Ціна - Ціна * 0.2" +
                "When OnSale = 4 Then Ціна - Ціна * 0.3" +
                " End as Нова from Cars");

            while (sqlDataReader.Read())
            {
                cars.Add(new Car()
                {
                    Id = Convert.ToInt32(sqlDataReader[0].ToString()),
                    Picture = sqlDataReader[1].ToString(),
                    CarName = sqlDataReader[2].ToString(),
                    Model = sqlDataReader[3].ToString(),
                    Year = sqlDataReader[4].ToString(),
                    Color = sqlDataReader[5].ToString(),
                    Engine = sqlDataReader[6].ToString(),
                    TypeofCar = sqlDataReader[7].ToString(),
                    Transmission = sqlDataReader[8].ToString(),
                    Mileage = sqlDataReader[9].ToString(),
                    CarAccident = sqlDataReader[10].ToString(),
                    CarInStock = sqlDataReader[11].ToString(),
                    Price = Convert.ToDecimal(sqlDataReader[12]),
                    CategoryId = Convert.ToInt32(sqlDataReader[13]),
                    SaleId = Convert.ToInt32(sqlDataReader[14]),



                });
                pricewithsale.Add(Convert.ToInt32(sqlDataReader[15]));
            }
            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();

            return cars;
        }
        public void Add(Car addcar)
        {
            _databaseConnection.Connection("Insert into Cars (Фото, Марка, Модель, [Рік випуску], " +
                 "Колір, [Тип двигуна], [Тип кузова], Коробка, Пробіг, [Участь у ДТП], [В наявності], Ціна, CategoryId, OnSale) " +
                 $"Values ('{addcar.Picture}', '{addcar.CarName}', '{addcar.Model}', " +
                 $"'{addcar.Year}', '{addcar.Color}', '{addcar.Engine}', " +
                 $"'{addcar.TypeofCar}', '{addcar.Transmission}', '{addcar.Mileage}', '{addcar.CarAccident}', '{addcar.CarInStock}', " +
                 $" {addcar.Price}, {addcar.CategoryId}, {addcar.SaleId})");

            _databaseConnection.reader.Close();
            _databaseConnection.connection.Close();
        }
        public void Edit(Car editcar)
        {
            string comand = "Update Cars Set ";
            if (editcar.Picture != null)
            {
                comand += $"Фото = '{editcar.Picture}', ";
            }
            if (editcar.CarName != null)
            {
                comand += $"Марка = '{editcar.CarName}', ";

            }
            if (editcar.Model != null)
            {
                comand += $"Модель = '{editcar.Model}', ";

            }
            if (editcar.Year != null)
            {
                comand += $"[Рік випуску] = '{editcar.Year}', ";
            }
            if (editcar.Color != null)
            {
                comand += $"Колір = '{editcar.Color}', ";
            }
            if (editcar.Engine != null)
            {
                comand += $"[Тип двигуна] = '{editcar.Engine}', ";
            }
            if (editcar.TypeofCar != null)
            {
                comand += $"[Тип кузова] = '{editcar.TypeofCar}', ";
            }
            if (editcar.Transmission != null)
            {
                comand += $"Коробка = '{editcar.Transmission}', ";
            }
            if (editcar.Mileage != null)
            {
                comand += $"Пробіг = '{editcar.Mileage}', ";
            }
            if (editcar.CarAccident != null)
            {
                comand += $"[Участь у ДТП] = '{editcar.CarAccident}', ";
            }
            if (editcar.CarInStock != null)
            {
                comand += $"[В наявності] = '{editcar.CarInStock}', ";
            }
            if (Convert.ToString(editcar.Price) != "0")
            {
                comand += $"Ціна = {editcar.Price}, ";
            }
            if (Convert.ToString(editcar.CategoryId) != "0")
            {
                comand += $"CategoryId = '{editcar.CategoryId}', ";
            }
            if (Convert.ToString(editcar.SaleId) != "0")
            {
                comand += $"OnSale = {editcar.SaleId}, ";
            }

            comand = comand.Substring(0, comand.Length - 2);
            comand += $" Where id = {editcar.Id}";

            _databaseConnection.Connection(comand);
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
