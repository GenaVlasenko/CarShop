using CarShop.Domain.Layer;
using System.Collections.Generic;

namespace CarShop.Data.Layer.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        void Add(Car addcar);
        void Edit(Car editcar);
        void Delete(int id);
    }
}
