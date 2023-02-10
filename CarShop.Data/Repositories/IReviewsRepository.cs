using CarShop.Domain.Layer;
using System.Collections.Generic;

namespace CarShop.Data.Layer.Repositories
{
    public interface IReviewsRepository
    {
        IEnumerable<Reviews> GetAll();
        void Add(Reviews reviews);
        void Edit(Reviews reviews);
        void Delete(int id);


    }
}
