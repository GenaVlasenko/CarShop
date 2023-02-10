using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Interfaces
{
    public interface IOrders
    {
        IEnumerable<Order> GetOrders { get; set; }
    }
}
