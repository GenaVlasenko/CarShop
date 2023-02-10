using CarShop.Domain.Layer;
using System.Collections.Generic;

namespace CarShop.Data.Layer.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        void Add(Order order);
        //void Edit(Order order);
        void Delete();

    }
}
