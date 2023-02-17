using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface ICarDetailService
    {
        IEnumerable<CarDetail> GetAll();
        Result Add(CarDetail carDetails);
    }
}
