using CarShop.Domain.Layer;
using CarShop.Domain.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable<Car> GetAllCars { get; set; }
        public IEnumerable<Contact> GetAllContacts { get; set; }
        public IEnumerable<Review> GetAllReviews { get; set; }
        public IEnumerable<Service> GetAllServices { get; set; }
        public IEnumerable<CarDetail> GetAllCarDetails { get; set; }


    }
}
