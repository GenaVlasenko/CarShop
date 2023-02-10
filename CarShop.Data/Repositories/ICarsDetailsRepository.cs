using CarShop.Domain.Layer;
using System.Collections.Generic;

namespace CarShop.Data.Layer.Repositories
{
    public interface ICarsDetailsRepository
    {
        IEnumerable<CarDetails> GetAll();
        void Add(CarDetails carDetails);
    }
}
