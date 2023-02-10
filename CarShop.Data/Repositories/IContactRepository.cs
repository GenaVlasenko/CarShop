using CarShop.Domain.Layer;
using System.Collections.Generic;


namespace CarShop.Data.Layer.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAll();
        void Add(Contact contact);
        void Edit(Contact Contact);
        void Delete(int id);

    }
}
