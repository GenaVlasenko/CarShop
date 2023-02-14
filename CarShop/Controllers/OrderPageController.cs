using CarShop.Business.Layer.Serveces;
using CarShop.Business.Layer.Services;
using CarShop.Domain.Layer;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarShop.Controllers
{
    public class OrderPageController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserApplicationService _callbackService;
        private readonly ICarService _carService;
        private string message = "OperationOk";
        private string caroder = "carorderid";
        private string callbackmessage = "callbackinfo";
        
        float pricewithsale;
        public OrderPageController(IOrderService orderService, IUserApplicationService callbackService, ICarService carService)
        {
            _orderService = orderService;
            _callbackService = callbackService;
            _carService = carService;
        }
        public IActionResult OrderPage(Car car)
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
        public void Order(Order order)
        {
            if (Request.Cookies["login"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.Admin = "1";
            }
            else
            {
                ViewBag.Admin = null;
            }
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
        public IEnumerable<Car> CarFromOrder(int id)
        {
            List<Car> onecars = new List<Car>();
            onecars = _carService.GetAll().Where(x => x.Id == id).ToList();

            float sale= _carService.GetAll().Where(x => x.Id == id).Select(x => x.SaleId).FirstOrDefault();
            pricewithsale = onecars.Select(x => x.Price * sale).FirstOrDefault();
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

        }
        public void SendCallback(UserApplication userApplication)
        {
            string messagecallback = string.Empty;
            var result = _callbackService.Add(userApplication);
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
