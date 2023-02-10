using CarShop.Business.Layer.Serveces;
using CarShop.Data.Interfaces;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ICompanyServices _companyServices;
        //private IServices allservices;
        public ServicesController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }
        public IActionResult Services()
        {
            if (Request.Cookies["key"] != null /*&& Request.Cookies["password"] != null*/)
            {
                ViewBag.Admin = "1";
            }
            else
            {
                ViewBag.Admin = null;
            }
            CarsListViewModels carsListViewModels = new CarsListViewModels();
            //carsListViewModels.GetAllServices = allservices.AllServices;
            carsListViewModels.GetAllServices = _companyServices.GetAll();
            return View(carsListViewModels.GetAllServices);
            
        }

    }
}
