using CarShop.Domain.Layer;
using System.Collections.Generic;


namespace CarShop.Data.Layer.Repositories
{
    public interface ICallbackRepository
    {
        IEnumerable<Callback> GetAll();
        void Add(Callback callback);
        void Delete();
        
    }
}
