using CarShop.Business.Layer.Serveces;
using CarShop.Domain.Layer;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarShop.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;
        private string cookie = "operationlabel";
        CookieOptions options;
        public ReviewsController(IReviewService reviewService)
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
        public void AddReview(Review review)
        {
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
        public void EditReview(Review review)
        {
            var result = _reviewService.Edit(review);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(",", result.Errors.Select(x => x.Message));
            }
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            
            Response.Redirect("/AdminPage/EditElement");
        }
        public void DeleteReview(int id)
        {
            var result = _reviewService.Delete(id);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(",", result.Errors.Select(x => x.Message));
            }
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            Response.Redirect("/AdminPage/DeleteElement");
        }
    }
}
