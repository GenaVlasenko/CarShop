using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        Result Add(Contact contacts);
        Result Edit(Contact contacts);
        Result Delete(int id);
    }
}
