using CarShop.Domain.Layer;
using System.Collections.Generic;

namespace CarShop.Data.Layer.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();
        void Add(Review reviews);
        void Edit(Review reviews);
        void Delete(int id);


    }
}
