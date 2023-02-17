using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface IReviewService
    {
        IEnumerable<Review> GetAll();
        Result Add(Review reviews);
        Result Edit(Review reviews);
        Result Delete(int id);




    }
}
