using CarShop.Domain.Layer;
using FluentResults;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface ICompanyServices
    {
        IEnumerable<CompanyService> GetAll();
        Result Add(CompanyService services);
        Result Edit(CompanyService services);
        void Delete(int id);

    }
}
