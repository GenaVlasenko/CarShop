using CarShop.Business.Layer.Serveces;
using CarShop.Domain.Layer;
using CarShop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;


namespace CarShop.Controllers
{
    public class ContactsController : Controller
    {
        private IContactService _contactsService;
        private string cookie = "operationlabel";
        CookieOptions options;
        public ContactsController(IContactService contactsService)
        {
            _contactsService = contactsService;
        }
        public ViewResult Contacts()
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
            carsListViewModels.GetAllContacts = _contactsService.GetAll().OrderBy(x => x.City);
            return View(carsListViewModels.GetAllContacts);
        }
        public void AddContact(Contact addcontact)
        {
           
            var result = _contactsService.Add(addcontact);
            string message = string.Empty;
            if(result.IsFailed)
            {
                message = string.Join(", ", result.Errors.Select(x => x.Message));
            }
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            
            Response.Redirect("/AdminPage/AddElement");
        }
        public void EditContact(Contact editcontact)
        {

            var result = _contactsService.Edit(editcontact);
            string message = string.Empty;
            if (result.IsFailed)
            {
                message = string.Join(", ", result.Errors.Select(x => x.Message));
            }
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            
            Response.Redirect("/AdminPage/EditElement");
        }
        public void DeleteContact(int id)
        {
            
            var result = _contactsService.Delete(id);
            string message = string.Empty;
            if(result.IsFailed)
            {
                message = string.Join(",", result.Errors.Select(x => x.Message));
            }
            options.Expires = DateTime.Now.AddSeconds(10);
            Response.Cookies.Append(cookie, message, options);
            
            Response.Redirect("/AdminPage/DeleteElement");
        }
    }
}
