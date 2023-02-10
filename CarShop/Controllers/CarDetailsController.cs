using CarShop.Business.Layer.Serveces;
using CarShop.Data.Interfaces;
using CarShop.Data.Mocks;
using CarShop.Data.Models;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly ICarsDetailsService _carDetailsService;
        private readonly ICarService _carService;

        //private ICarsDetails carsDetails;
        //SqlDataReader sqlDataReader;
        decimal pricewithsale;
        public CarDetailsController(ICarsDetailsService carDetailsService, ICarService carService)
        {
            _carDetailsService = carDetailsService;
            _carService = carService;
        }
        public IActionResult Index(CarShop.Domain.Layer.Car car)
        {
            try
            {
                CarsListViewModels carsListViewModels = new CarsListViewModels();
                //carsListViewModels.GetAllCarDetails = (IEnumerable<Domain.Layer.CarDetails>)carsDetails.AllCarsDetails.Where(x => x.car_id == car.Id);

                carsListViewModels.GetAllCarDetails = _carDetailsService.GetAll().Where(x => x.Id == car.Id);
                GetOneCar(car.Id);
                ViewBag.Layout = carsListViewModels.GetAllCarDetails.Where(x => x.Car_id == car.Id).First().Video;
                return View(carsListViewModels.GetAllCarDetails);

            }
            catch
            {
                return View(null);
            }
            
            
        }

        public void GetOneCar(int id)
        {
            List<CarShop.Domain.Layer.Car> onecars = new List<CarShop.Domain.Layer.Car>();
            onecars = _carService.GetAll().Where(x => x.Id == id).ToList();

            int number = _carService.GetAll().Where(x => x.Id == id).Select(x => x.SaleId).First();
            switch (number)
            {
                case 1:
                    {
                        pricewithsale = onecars.Select(x => x.Price).First();
                        break;
                    }
                case 2:
                    {
                        pricewithsale = onecars.Select(x => x.Price * Convert.ToDecimal(0.1)).First();
                        break;
                    }
                case 3:
                    {
                        pricewithsale = onecars.Select(x => x.Price * Convert.ToDecimal(0.2)).First();
                        break;
                    }
                case 4:
                    {
                        pricewithsale = onecars.Select(x => x.Price * Convert.ToDecimal(0.3)).First();
                        break;
                    }
            }
            ViewBag.OneCar = onecars;
            //DataCars mockCars = new DataCars();
            //DatabaseConnection connection = new DatabaseConnection();
            //sqlDataReader = connection.Connection("Select *, Case " +
            //    " When OnSale = 1 Then Ціна * 1  " +
            //    "When OnSale = 2 Then Ціна - Ціна * 0.1" +
            //    "When OnSale = 3 Then Ціна - Ціна * 0.2" +
            //    "When OnSale = 4 Then Ціна - Ціна * 0.3" +
            //    $" End as Нова from Cars Where id = '{id}'");



            //while (sqlDataReader.Read())
            //{
            //    onecars.Add(new Car()
            //    {
            //        id = Convert.ToInt32(sqlDataReader[0].ToString()),
            //        Picture = sqlDataReader[1].ToString(),
            //        CarName = sqlDataReader[2].ToString(),
            //        Model = sqlDataReader[3].ToString(),
            //        Year = sqlDataReader[4].ToString(),
            //        Color = sqlDataReader[5].ToString(),
            //        Engine = sqlDataReader[6].ToString(),
            //        TypeofCar = sqlDataReader[7].ToString(),
            //        Transmission = sqlDataReader[8].ToString(),
            //        Mileage = sqlDataReader[9].ToString(),
            //        CarAccident = sqlDataReader[10].ToString(),
            //        CarInStock = sqlDataReader[11].ToString(),
            //        Price = Convert.ToDecimal(sqlDataReader[12]),
            //        CategoryId = Convert.ToInt32(sqlDataReader[13]),
            //        SaleId = Convert.ToInt32(sqlDataReader[14]),


            //    });

            //    pricewithsale = Convert.ToInt32(sqlDataReader[15]);
            //}
            //ViewBag.OneCar = onecars;


        }

        public void AddCarsDetails(CarShop.Domain.Layer.CarDetails carDetails)
        {
            //DataCarDetails mockCarDetails = new DataCarDetails();
            _carDetailsService.Add(carDetails);
            //mockCarDetails.AddCarsDetails(carDetails);
        }

    }
}
