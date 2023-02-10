using CarShop.Domain.Layer;
using System.Collections.Generic;


namespace CarShop.Data.Layer.Repositories
{
    public interface ICompanyServicesRepository
    {
        IEnumerable<CompanyService> GetAll();
        void Add(CompanyService services);
        void Edit(CompanyService services);
        void Delete(int id);

    }
}
