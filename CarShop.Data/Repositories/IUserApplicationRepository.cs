using CarShop.Domain.Layer;
using System.Collections.Generic;


namespace CarShop.Data.Layer.Repositories
{
    public interface IUserApplicationRepository
    {
        IEnumerable<UserApplication> GetAll();
        void Add(UserApplication callback);
        void Delete();
        
    }
}
