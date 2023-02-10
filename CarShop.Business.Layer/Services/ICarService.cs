using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Result Add(Car addcar);
        Result Edit(Car editcar);
        Result Delete(int id);
    }
}
