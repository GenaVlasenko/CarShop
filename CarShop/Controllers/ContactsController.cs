using CarShop.Business.Layer.Serveces;
using CarShop.Data.Interfaces;
using CarShop.Data.Mocks;
using CarShop.Data.Models;
using CarShop.Domain.Layer;
using CarShop.ViewModels;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class ContactsController : Controller
    {
        private IContactsService _contactsService;
        //private IContacts allContacts;
        private string cookie = "operationlabel";
        CookieOptions options;
        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        public ViewResult Contacts()
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
            carsListViewModels.GetAllContacts = _contactsService.GetAll().OrderBy(x => x.City);
            return View(carsListViewModels.GetAllContacts);
        }
        public void AddContact(Contact addcontact)
        {
            //DataContacts mockContacts = new DataContacts();

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

            //DataContacts mockContacts = new DataContacts();
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
            //DataContacts mockContacts = new DataContacts();
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
