using CarShop.Data.Models;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable<Domain.Layer.Car> GetAllCars { get; set; }
        public IEnumerable<Contact> GetAllContacts { get; set; }
        public IEnumerable<Domain.Layer.Reviews> GetAllReviews { get; set; }
        public IEnumerable<CompanyService> GetAllServices { get; set; }
        public IEnumerable<Domain.Layer.CarDetails> GetAllCarDetails { get; set; }


    }
}
