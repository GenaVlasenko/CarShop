using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarShop.Data.Mocks
{
    public class DataCars : IAllCars
    {
        public IEnumerable<Car> AllCars { get; set; }
        CheckBeforeWriting checkBeforeWriting;
        DatabaseConnection databaseConnection;
        SqlDataReader sqlDataReader;
        public static List<int> pricewithsale;
        List<Car> cars;
        string empty = " поле пусте";
        string warning = " містить спецсимволи";
        public DataCars()
        {
            databaseConnection = new DatabaseConnection();
            AllCars = GetAllCars();
            

        }
        private IEnumerable<Car> GetAllCars()
        {
            cars = new List<Car>();
            pricewithsale = new List<int>();
            sqlDataReader = databaseConnection.Connection("Select *, Case " +
                " When OnSale = 1 Then Ціна * 1  " +
                "When OnSale = 2 Then Ціна - Ціна * 0.1" +
                "When OnSale = 3 Then Ціна - Ціна * 0.2" +
                "When OnSale = 4 Then Ціна - Ціна * 0.3" +
                " End as Нова from Cars");

            while (sqlDataReader.Read())
            {
                cars.Add(new Car()
                {
                    id = Convert.ToInt32(sqlDataReader[0].ToString()),
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
            databaseConnection.reader.Close();
            databaseConnection.connection.Close();
            return cars;
        }
        public string AddNewCar(Car addcar)
        {
            
            checkBeforeWriting = new CheckBeforeWriting();
            if (addcar.CarName != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.CarName)) { }
                else { return $"Поле Марка" + warning; }

            }
            else
            {
                return $"{addcar.CarName}" + empty;
            }

            if (addcar.Model != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.Model)) { }
                else { return $"Поле Модель" + warning; }

            }
            else
            {
                return $"Поле Модель" + empty;
            }

            if (addcar.Year != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.Year)) { }
                else { return $"Поле Рік випуску" + warning; }

            }
            else
            {
                return $"Поле Рік випуску" + empty;
            }

            if (addcar.Color != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.Color)) { }
                else { return $"Поле Колір" + warning; }

            }
            else
            {
                return $"Поле Колір" + empty;
            }

            if (addcar.Engine != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.Engine)) { }
                else { return $"Поле Тип двигуна" + warning; }

            }
            else
            {
                return $"Поле Тип двигуна" + empty;
            }

            if (addcar.TypeofCar != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.TypeofCar)) { }
                else { return $"Поле Тип кузова" + warning; }

            }
            else
            {
                return $"Поле Тип кузова" + empty;
            }

            if (addcar.Transmission != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.Transmission)) { }
                else { return $"Поле Коробка" + warning; }

            }
            else
            {
                return $"Поле Коробка" + empty;
            }

            if (addcar.Mileage != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.Mileage)) { }
                else { return $"Поле Пробіг" + warning; }

            }
            else
            {
                return $"Поле Пробіг" + empty;
            }

            if (addcar.CarAccident != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.CarAccident)) { }
                else { return $"Поле Був в ДТП" + warning; }

            }
            else
            {
                return $"Поле Був в ДТП" + empty;
            }

            if (addcar.CarInStock != null)
            {
                if (checkBeforeWriting.Special_Characters(addcar.CarInStock)) { }
                else { return $"Поле В наявності" + warning; }

            }
            else
            {
                return $"Поле В наявності" + empty;
            }

            if (Convert.ToString(addcar.Price) != "0")
            {
                if (checkBeforeWriting.Special_Characters(Convert.ToString(addcar.Price))) { }
                else { return $"Поле Ціна" + warning; }

            }
            else
            {
                return $"Поле Ціна" + empty;
            }

            if (Convert.ToString(addcar.CategoryId) != "0")
            {
                if (checkBeforeWriting.Special_Characters(Convert.ToString(addcar.CategoryId))) { }
                else { return $"Поле CarId" + warning; }

            }
            else
            {
                return $"Поле CarId" + empty;
            }

            if (Convert.ToString(addcar.SaleId) != "0")
            {
                if (checkBeforeWriting.Special_Characters(Convert.ToString(addcar.SaleId))) { }
                else { return $"Поле SaleId" + warning; }

            }
            else
            {
                return $"Поле SaleId" + empty;
            }

            try
            {
                databaseConnection.Connection("Insert into Cars (Фото, Марка, Модель, [Рік випуску], " +
                 "Колір, [Тип двигуна], [Тип кузова], Коробка, Пробіг, [Участь у ДТП], [В наявності], Ціна, CategoryId, OnSale) " +
                 $"Values ('{addcar.Picture}', '{addcar.CarName}', '{addcar.Model}', " +
                 $"'{addcar.Year}', '{addcar.Color}', '{addcar.Engine}', " +
                 $"'{addcar.TypeofCar}', '{addcar.Transmission}', '{addcar.Mileage}', '{addcar.CarAccident}', '{addcar.CarInStock}', " +
                 $" {addcar.Price}, {addcar.CategoryId}, {addcar.SaleId})");

            }
            catch
            {
                return "Сталася помилка при додаванні данних";
            }
            databaseConnection.reader.Close();
            databaseConnection.connection.Close();
            return "Дані успішно записані";
        }
        public string EditCar(Car editcar)
        {
            checkBeforeWriting = new CheckBeforeWriting();
            if (cars.Select(x=>x.id).Contains(editcar.id))
            {
                string comand = "Update Cars Set ";
                if (editcar.Picture != null)
                {
                    comand += $"Фото = '{editcar.Picture}', ";
                }
                if (editcar.CarName != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.CarName))
                    {
                        comand += $"Марка = '{editcar.CarName}', ";
                    }
                    else
                    {
                        return "Поле Марка" + warning;
                    }

                }
                if (editcar.Model != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.Model))
                    {
                        comand += $"Модель = '{editcar.Model}', ";
                    }
                    else
                    {
                        return $"Поле Модель" + warning;
                    }

                }
                if (editcar.Year != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.Year))
                    {
                        comand += $"[Рік випуску] = '{editcar.Year}', ";
                    }
                    else
                    {
                        return $"поле Рік випуску" + warning;
                    }
                }
                if (editcar.Color != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.Color))
                    {
                        comand += $"Колір = '{editcar.Color}', "; ;
                    }
                    else
                    {
                        return $"Поле Колір" + warning;
                    }

                }
                if (editcar.Engine != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.Engine))
                    {
                        comand += $"[Тип двигуна] = '{editcar.Engine}', ";
                    }
                    else
                    {
                        return $"Поле Тип двигуна" + warning;
                    }


                }
                if (editcar.TypeofCar != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.TypeofCar))
                    {
                        comand += $"[Тип кузова] = '{editcar.TypeofCar}', ";
                    }
                    else
                    {
                        return $"Тип кузова" + warning;
                    }


                }
                if (editcar.Transmission != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.Transmission))
                    {
                        comand += $"Коробка = '{editcar.Transmission}', ";
                    }
                    else
                    {
                        return $"Поле коробка" + warning;
                    }


                }
                if (editcar.Mileage != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.Mileage))
                    {
                        comand += $"Пробіг = '{editcar.Mileage}', ";
                    }
                    else
                    {
                        return $"Поле Пробіг" + warning;
                    }


                }
                if (editcar.CarAccident != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.CarAccident))
                    {
                        comand += $"[Участь у ДТП] = '{editcar.CarAccident}', ";
                    }
                    else
                    {
                        return $"Участь у ДТП" + warning;
                    }


                }
                if (editcar.CarInStock != null)
                {
                    if (checkBeforeWriting.Special_Characters(editcar.CarInStock))
                    {
                        comand += $"[В наявності] = '{editcar.CarInStock}', ";
                    }
                    else
                    {
                        return $"Поле В наявності" + warning;
                    }

                }
                if (Convert.ToString(editcar.Price) != "0")
                {
                    if (checkBeforeWriting.Special_Characters(Convert.ToString(editcar.Price)))
                        comand += $"Ціна = {editcar.Price}, ";
                    else { return $"Поле Ціна" + warning; }

                }
                if (Convert.ToString(editcar.CategoryId) != "0")
                {
                    if (checkBeforeWriting.Special_Characters(Convert.ToString(editcar.CategoryId)))
                        comand += $"CategoryId = '{editcar.CategoryId}', ";
                    else { return $"CarId" + warning; }

                }
                if (Convert.ToString(editcar.SaleId) != "0")
                {
                    if (checkBeforeWriting.Special_Characters(Convert.ToString(editcar.SaleId)))
                        comand += $"OnSale = {editcar.SaleId}, ";
                    else { return $"Поле SaleId" + warning; }
                }

                comand = comand.Substring(0, comand.Length - 2);
                comand += $" Where id = {editcar.id}";
                try
                {
                    databaseConnection.Connection(comand);
                }
                catch
                {
                    return "Сталася помилка при редагуванні данних";
                }
                databaseConnection.reader.Close();
                databaseConnection.connection.Close();
                return "Дані успішно перезаписані";

            }
            else
            {
                databaseConnection.reader.Close();
                databaseConnection.connection.Close();
                return "Введенний id некорректний";
            }
            

        }
        public string DeleteCar(int id)
        {
            checkBeforeWriting = new CheckBeforeWriting();
            if(cars.Select(x => x.id).Contains(id))
            {
                if (id != 0)
                {
                    if (checkBeforeWriting.Special_Characters(Convert.ToString(id)))
                    {
                        try
                        {
                            databaseConnection.Connection($"Delete Cars Where id = {id}");

                        }
                        catch
                        {
                            return "Невірно введений ідентифікатор";
                        }

                    }
                    else
                    {
                        return "поле Id містить специфічні символи, введіть будь ласка корректні дані";
                    }
                }
                else
                {
                    return $"поле Id пусте";
                }
                databaseConnection.reader.Close();
                databaseConnection.connection.Close();
                return "Дані успішно видалені";

            }
            else
            {
                databaseConnection.reader.Close();
                databaseConnection.connection.Close();
                return "Введенний id некорректний";
            }
           
            
        }
        public IEnumerable<Car>GetSortedCars(int minprice, int maxprice)
        {
            cars = new List<Car>();
            pricewithsale = new List<int>();
            sqlDataReader = databaseConnection.Connection("Select * , Case " +
                " When OnSale = 1 Then Ціна * 1  " +
                "When OnSale = 2 Then Ціна - Ціна * 0.1" +
                "When OnSale = 3 Then Ціна - Ціна * 0.2" +
                "When OnSale = 4 Then Ціна - Ціна * 0.3" +
                $" End as Нова from Cars Where Нова BETWEEN {minprice} AND {maxprice}");

            while (sqlDataReader.Read())
            {
                cars.Add(new Car()
                {
                    id = Convert.ToInt32(sqlDataReader[0].ToString()),
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
            databaseConnection.reader.Close();
            databaseConnection.connection.Close();
            return cars;
        }
        
        
    }
}
