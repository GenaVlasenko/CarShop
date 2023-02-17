using CarShop.Domain.Layer;
using CarShop.Domain.Layer.Entities;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface IService
    {
        IEnumerable<Service> GetAll();
        Result Add(Service services);
        Result Edit(Service services);
        void Delete(int id);

    }
}
