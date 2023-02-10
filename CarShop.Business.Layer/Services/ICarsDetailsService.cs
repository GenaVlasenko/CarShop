using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface ICarsDetailsService
    {
        IEnumerable<CarDetails> GetAll();
        Result Add(CarDetails carDetails);
    }
}
