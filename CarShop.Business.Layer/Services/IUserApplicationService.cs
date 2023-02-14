using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;


namespace CarShop.Business.Layer.Services
{
    public interface IUserApplicationService
    {
        IEnumerable<UserApplication> GetAll();
        Result Add(UserApplication callback);
        Result Delete();


    }
}
