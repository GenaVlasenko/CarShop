using CarShop.Business.Layer.Serveces;
using CarShop.Business.Layer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarShop.Controllers
{
    public class AdminPageController : Controller
    { 

        private readonly IOrderService _orderService;
        private readonly ICarService _carService;
        private readonly IUserApplicationService _callbackService;

        private string cookie = "key";
        private string cookielogin = "login";
        private string cookiepassword = "password";
        private string cookieorders = "cookieorders";
        private string cookiecallbacks = "cookiecallbacks";
        CookieOptions options;

        public AdminPageController(IOrderService orderService, ICarService carService, IUserApplicationService callbackService)
        {
            _orderService = orderService;
            _carService = carService;
            _callbackService = callbackService;
        }
        public void Check(string login, string password)
        {
            options = new CookieOptions();
            LoginPassword loginPassword = new LoginPassword();
            if (login == loginPassword.login & password == loginPassword.password)
            {

                ViewBag.Admin = "1";
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(cookie, "1", options);
                Response.Cookies.Append(cookielogin, loginPassword.login, options);
                Response.Cookies.Append(cookiepassword, loginPassword.password, options);
                
                Response.Redirect("/Home/Index");

            }
            else
            {
                if(login == null || password == null)
                {
                    ViewBag.Admin = null;
                    options.Expires = DateTime.Now.AddSeconds(5);
                    Response.Cookies.Append(cookie, "null", options);
                    
                    Response.Redirect("/Home/Index");
                }
                else
                {
                    ViewBag.Admin = "0";
                    options.Expires = DateTime.Now.AddSeconds(5);
                    Response.Cookies.Append(cookie, "0", options);
                    
                    Response.Redirect("/Home/Index");

                }
                
            }
        }
        public IActionResult AdminPage()
        {
            ViewBag.Admin = "1";
            ViewBag.OrdersMessage = Request.Cookies["cookieorders"];
            ViewBag.CallbacksMessage = Request.Cookies["cookiecallbacks"];
            ViewBag.AllCallbacks = _orderService.GetAll();
            return View(_orderService.GetAll());

        }
        public IActionResult AddElement()
        {
            CheckCookie();
            return View();
            
        }
        public IActionResult EditElement()
        {
            CheckCookie();
            return View();

        }
        public IActionResult DeleteElement()
        {
            CheckCookie();
            return View();

        }
        public void DeleteAllOrders()
        {
            var orderresult = _orderService.Delete();
            var callbackresult = _callbackService.Delete();

            string messageorders = string.Empty;
            string messagecallbacks = string.Empty;
            if (orderresult.IsFailed)
            {
                messageorders = string.Join(", ", orderresult.Errors.Select(x => x.Message));
                
            }
            if(callbackresult.IsFailed)
            {
                messagecallbacks = string.Join(", ", callbackresult.Errors.Select(x => x.Message));
            }
            

            CookieOptions options2 = new CookieOptions();
            options2.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookieorders, messageorders, options2);
            Response.Cookies.Append(cookiecallbacks, messagecallbacks, options2);
            
            Response.Redirect("/AdminPage/AdminPage");
        }
        public void CheckCookie()
        {
            ViewBag.Message = Request.Cookies["operationlabel"];
            if (Request.Cookies["login"] != null && Request.Cookies["password"] != null)
            {
                ViewBag.Admin = "1";
            }
            else
            {
                ViewBag.Admin = null;
            }

        }
        
        
        
    }
}
