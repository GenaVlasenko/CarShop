using CarShop.Business.Layer.Serveces;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IService _companyServices;
        public ServicesController(IService companyServices)
        {
            _companyServices = companyServices;
        }
        public IActionResult Services()
        {
            if (Request.Cookies["key"] != null)
            {
                ViewBag.Admin = "1";
            }
            else
            {
                ViewBag.Admin = null;
            }
            CarsListViewModels carsListViewModels = new CarsListViewModels();
            carsListViewModels.GetAllServices = _companyServices.GetAll();
            return View(carsListViewModels.GetAllServices);
            
        }

    }
}
