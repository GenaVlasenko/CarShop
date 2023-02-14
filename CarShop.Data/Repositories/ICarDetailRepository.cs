using CarShop.Domain.Layer;
using System.Collections.Generic;

namespace CarShop.Data.Layer.Repositories
{
    public interface ICarDetailRepository
    {
        IEnumerable<CarDetail> GetAll();
        void Add(CarDetail carDetails);
    }
}
