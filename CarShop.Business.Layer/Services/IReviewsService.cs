using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface IReviewsService
    {
        IEnumerable<Reviews> GetAll();
        Result Add(Reviews reviews);
        Result Edit(Reviews reviews);
        Result Delete(int id);




    }
}
