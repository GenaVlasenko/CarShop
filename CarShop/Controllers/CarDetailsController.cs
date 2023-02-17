using CarShop.Business.Layer.Serveces;
using CarShop.Domain.Layer;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly ICarDetailService _carDetailsService;
        private readonly ICarService _carService;
        float pricewithsale;
        public CarDetailsController(ICarDetailService carDetailsService, ICarService carService)
        {
            _carDetailsService = carDetailsService;
            _carService = carService;
        }
        public IActionResult GetAll(Car car)
        {
            try
            {
                CarsListViewModels carsListViewModels = new CarsListViewModels();
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
            List<Car> onecars = new List<Car>();
            onecars = _carService.GetAll().Where(x => x.Id == id).ToList();

            float number = _carService.GetAll().Where(x => x.Id == id).Select(x => x.SaleId).First();
            pricewithsale = onecars.Select(x => x.Price - x.Price * number).First();
            ViewBag.OneCar = onecars;
           
        }

        public void AddCarsDetails(CarDetail carDetails)
        {
            
            _carDetailsService.Add(carDetails);
       
        }

    }
}
