using CarShop.Business.Layer.Serveces;
using CarShop.Data.Interfaces;
using CarShop.Data.Mocks;
using CarShop.Data.Models;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class ReviewsController : Controller
    {
        //private IReviews reviews;
        private readonly IReviewsService _reviewService;
        private string cookie = "operationlabel";
        CookieOptions options;
        public ReviewsController(IReviewsService reviewService)
        {
            _reviewService = reviewService;
            options = new CookieOptions();
        }
        public IActionResult Reviews()
        {
            if (Request.Cookies["key"] != null )
            {
                ViewBag.Admin = "1";
            }
            else
            {
                ViewBag.Admin = null;
            }
            CarsListViewModels carsListViewModels = new CarsListViewModels();
            carsListViewModels.GetAllReviews = _reviewService.GetAll();
            return View(carsListViewModels.GetAllReviews);
        }
        public void AddReview(CarShop.Domain.Layer.Reviews review)
        {
            //DataReviews mockReviews = new DataReviews();
            var result =_reviewService.Add(review);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(",", result.Errors.Select(x => x.Message));
            }

            
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            
            Response.Redirect("/AdminPage/AddElement");


        }
        public void EditReview(CarShop.Domain.Layer.Reviews review)
        {
            //DataReviews mockReviews = new DataReviews();
            var result = _reviewService.Edit(review);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(",", result.Errors.Select(x => x.Message));
            }
            //message = mockReviews.EditReview(review);
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            
            Response.Redirect("/AdminPage/EditElement");
        }
        public void DeleteReview(int id)
        {
            //DataReviews mockReviews = new DataReviews();
            var result = _reviewService.Delete(id);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(",", result.Errors.Select(x => x.Message));
            }
            //message = mockReviews.DeleteReview(id);
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            
            Response.Redirect("/AdminPage/DeleteElement");
        }
    }
}
