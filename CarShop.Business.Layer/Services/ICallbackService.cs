using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;


namespace CarShop.Business.Layer.Services
{
    public interface ICallbackService
    {
        IEnumerable<Callback> GetAll();
        Result Add(Callback callback);
        Result Delete();


    }
}
