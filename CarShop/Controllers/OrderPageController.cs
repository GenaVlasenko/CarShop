using CarShop.Business.Layer.Serveces;
using CarShop.Business.Layer.Services;
using CarShop.Data.Interfaces;
using CarShop.Data.Mocks;
using CarShop.Data.Models;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class OrderPageController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICallbackService _callbackService;
        private readonly ICarService _carService;

        //private IOrders orders;
        //SqlDataReader sqlDataReader;
        private string message = "OperationOk";
        private string caroder = "carorderid";
        private string callbackmessage = "callbackinfo";
        
        decimal pricewithsale;
        public OrderPageController(IOrderService orderService, ICallbackService callbackService, ICarService carService)
        {
            _orderService = orderService;
            _callbackService = callbackService;
            _carService = carService;
        }
        public IActionResult OrderPage(CarShop.Domain.Layer.Car car)
        {
            
            if (car.Id != 0)
            {
                return View(CarFromOrder(car.Id));

            }
            else
            {
                int id = Convert.ToInt32(Request.Cookies["carorderid"]);
                return View(CarFromOrder(id));
            }
            


        }
        public void Order(CarShop.Domain.Layer.Order order)
        {
            if (Request.Cookies["login"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.Admin = "1";
            }
            else
            {
                ViewBag.Admin = null;
            }
            //DataOrder mockOrder = new DataOrder();
            var result = _orderService.Add(order);
            string messagefromorders = string.Empty;
            if (result.IsFailed)
            {
                messagefromorders = string.Join(",", result.Errors.Select(x => x.Message));
            }
            
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddSeconds(5);
            Response.Cookies.Append(message, messagefromorders, options);
            Response.Redirect("/OrderPage/OrderPage");

        }
        public IEnumerable<CarShop.Domain.Layer.Car> CarFromOrder(int id)
        {
            

            List<CarShop.Domain.Layer.Car> onecars = new List<CarShop.Domain.Layer.Car>();
            onecars = _carService.GetAll().Where(x => x.Id == id).ToList();

            int number = _carService.GetAll().Where(x => x.Id == id).Select(x => x.SaleId).FirstOrDefault();
            switch (number)
            {
                case 1:
                    {
                        pricewithsale = onecars.Select(x => x.Price).FirstOrDefault();
                        break;
                    }
                case 2:
                    {
                        pricewithsale = onecars.Select(x => x.Price * Convert.ToDecimal(0.1)).FirstOrDefault();
                        break;
                    }
                case 3:
                    {
                        pricewithsale = onecars.Select(x => x.Price * Convert.ToDecimal(0.2)).FirstOrDefault();
                        break;
                    }
                case 4:
                    {
                        pricewithsale = onecars.Select(x => x.Price * Convert.ToDecimal(0.3)).FirstOrDefault();
                        break;
                    }
            }

            ViewBag.PriceWithSale = pricewithsale;
            ViewBag.OperationOK = Request.Cookies["OperationOk"];
            if (Request.Cookies["login"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.Admin = "1";
            }
            else
            {
                ViewBag.Admin = null;
            }
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(3);
            Response.Cookies.Append(caroder, Convert.ToString(id), options);
            return onecars;

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



        }
        public void SendCallback(CarShop.Domain.Layer.Callback callback)
        {
            string messagecallback = string.Empty;
            var result = _callbackService.Add(callback);
            if(result.IsFailed)
            {
                messagecallback = string.Join(",",result.Errors.Select(x=>x.Message));
            }
            CookieOptions options2 = new CookieOptions();
            options2.Expires = DateTime.Now.AddSeconds(5);
            Response.Cookies.Append(callbackmessage, messagecallback, options2);
            Response.Redirect("/Home/Index");


        }

    }
}
