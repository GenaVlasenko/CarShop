using CarShop.Domain.Layer;
using CarShop.Domain.Layer.Entities;
using System.Collections.Generic;


namespace CarShop.Data.Layer.Repositories
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
        void Add(Service services);
        void Edit(Service services);
        void Delete(int id);

    }
}
