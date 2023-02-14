using CarShop.Business.Layer.Serveces;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using CarShop.Domain.Layer;
using System.Collections.Generic;

namespace CarShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        
        string message = string.Empty;
        private string cookie = "operationlabel";
        CarsListViewModels carsListViewModels;
        CookieOptions options;
        public HomeController(ICarService carService)
        {
            options = new CookieOptions();
            _carService = carService;
        }
        public IActionResult Index(string car, int _minprice, int _maxprice)
        { 
            CheckViewBag();
            carsListViewModels = new CarsListViewModels();
            carsListViewModels.GetAllCars = _carService.GetAll();
            List<float> pricewithsalelist = new List<float>();
            ViewBag.CallbackInfo = Request.Cookies["callbackinfo"];
            int minprice = _minprice == 0 ? 0 : _minprice;
            int maxprice = _maxprice == 0 ? 1000000 : _maxprice;

            foreach (var item in _carService.GetAll())
            {
                float pricewithsale = item.Price * item.SaleId;
                if(pricewithsale == item.Price)
                {
                    pricewithsalelist.Add(item.Price);
                }
                else
                {
                    pricewithsalelist.Add(item.Price - pricewithsale);
                }
                
            }
            ViewBag.PriceWithSale = pricewithsalelist;

            if (car != null)
            {
                if (carsListViewModels.GetAllCars.Select(x => x.Engine).Distinct().OrderBy(x => x).Contains(car))
                {
                    ViewBag.TypeofCar = carsListViewModels.GetAllCars.Where(x => x.Engine == car).Select(x => x.TypeofCar).Distinct().OrderBy(x => x);
                    ViewBag.Engine = carsListViewModels.GetAllCars.Select(x => x.Engine).Distinct().OrderBy(x => x);
                    ViewBag.Car = carsListViewModels.GetAllCars.Where(x => x.Engine == car).Select(x => x.Brand).Distinct().OrderBy(x => x);
                    ViewBag.Model = carsListViewModels.GetAllCars.Where(x => x.Engine == car).Select(x => x.Model).Distinct().OrderBy(x => x);
                    carsListViewModels.GetAllCars = carsListViewModels.GetAllCars.Where(x => x.Engine == car).ToList();
                    ViewBag.EngineDropDown = car;
                }
                else
                {
                    if (carsListViewModels.GetAllCars.Select(x => x.TypeofCar).Distinct().OrderBy(x => x).Contains(car))
                    {
                        ViewBag.Engine = carsListViewModels.GetAllCars.Where(x => x.TypeofCar == car).Select(x => x.Engine).Distinct().OrderBy(x => x);
                        ViewBag.TypeofCar = carsListViewModels.GetAllCars.Select(x => x.TypeofCar).Distinct().OrderBy(x => x);
                        ViewBag.Car = carsListViewModels.GetAllCars.Where(x => x.TypeofCar == car).Select(x => x.Brand).Distinct().OrderBy(x => x);
                        ViewBag.Model = carsListViewModels.GetAllCars.Where(x => x.TypeofCar == car).Select(x => x.Model).Distinct().OrderBy(x => x);
                        carsListViewModels.GetAllCars = carsListViewModels.GetAllCars.Where(x => x.TypeofCar == car).ToList();
                        ViewBag.TypeofCarDropDown = car;
                    }
                    else
                    {
                        if (carsListViewModels.GetAllCars.Select(x => x.Brand).Distinct().OrderBy(x => x).Contains(car))
                        {
                            ViewBag.TypeofCar = carsListViewModels.GetAllCars.Where(x => x.Brand == car).Select(x => x.TypeofCar).Distinct().OrderBy(x => x);
                            ViewBag.Engine = carsListViewModels.GetAllCars.Where(x => x.Brand == car).Select(x => x.Engine).Distinct().OrderBy(x => x);
                            ViewBag.Car = carsListViewModels.GetAllCars.Select(x => x.Brand).Distinct().OrderBy(x => x);
                            ViewBag.Model = carsListViewModels.GetAllCars.Where(x => x.Brand == car).Select(x => x.Model).Distinct().OrderBy(x => x);
                            carsListViewModels.GetAllCars = carsListViewModels.GetAllCars.Where(x => x.Brand == car).ToList();
                            ViewBag.CarNameDropDown = car;
                        }
                        else
                        {
                            if (carsListViewModels.GetAllCars.Select(x => x.Model).Distinct().OrderBy(x => x).Contains(car))
                            {
                                ViewBag.TypeofCar = carsListViewModels.GetAllCars.Where(x => x.Model == car).Select(x => x.TypeofCar).Distinct().OrderBy(x => x);
                                ViewBag.Engine = carsListViewModels.GetAllCars.Where(x => x.Model == car).Select(x => x.Engine).Distinct().OrderBy(x => x);
                                ViewBag.Car = carsListViewModels.GetAllCars.Where(x => x.Model == car).Select(x => x.Brand).Distinct().OrderBy(x => x);
                                ViewBag.Model = carsListViewModels.GetAllCars.Select(x => x.Model).Distinct().OrderBy(x => x);
                                carsListViewModels.GetAllCars = carsListViewModels.GetAllCars.Where(x => x.Model == car).ToList();
                                ViewBag.ModelDropDown = car;
                            }
                            
                        }
                    }
                }
            }
            else
            {

                ViewBag.Engine = carsListViewModels.GetAllCars.Where(x => x.Price > minprice && x.Price < maxprice).Select(x => x.Engine).Distinct().OrderBy(x => x);
                ViewBag.TypeofCar = carsListViewModels.GetAllCars.Where(x => x.Price > minprice && x.Price < maxprice).Select(x => x.TypeofCar).Distinct().OrderBy(x => x);
                ViewBag.Car = carsListViewModels.GetAllCars.Where(x => x.Price > minprice && x.Price < maxprice).Select(x => x.Brand).Distinct().OrderBy(x => x);
                ViewBag.Model = carsListViewModels.GetAllCars.Where(x => x.Price > minprice && x.Price < maxprice).Select(x => x.Model).Distinct().OrderBy(x => x);
                carsListViewModels.GetAllCars = carsListViewModels.GetAllCars.Where(x => x.Price > minprice && x.Price < maxprice).ToList();


            }
            return View(carsListViewModels);
             
        }
        public void AddCar(Car addcar)
        {
            var result = _carService.Add(addcar);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(", ", result.Errors.Select(x => x.Message));
            }

            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            Response.Redirect("/AdminPage/AddElement");


        }
        public void EditCar(Car editcar)
        {
            var result = _carService.Edit(editcar);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(", ", result.Errors.Select(x => x.Message));
            }
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            Response.Redirect("/AdminPage/EditElement");


        }
        public void DeleteCar(int id)
        {
            var result = _carService.Delete(id);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(", ", result.Errors.Select(x => x.Message));
            }
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            Response.Redirect("/AdminPage/DeleteElement");


        }
        public void CheckViewBag()
        {
            string number = Request.Cookies["key"];
            switch (number)
            {
                case "1":
                    {
                        ViewBag.Admin = "1";
                        break;
                    }
                case "0":
                    {
                        ViewBag.Admin = "0";
                        break;
                    }
                case null:
                    {
                        ViewBag.Admin = null;
                        break;
                    }

            }

        }




    }
}
