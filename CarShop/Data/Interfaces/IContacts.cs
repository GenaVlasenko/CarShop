using CarShop.Data.Models;
using System.Collections.Generic;


namespace CarShop.Data.Interfaces
{
    public interface IContacts
    {
        IEnumerable<Contacts> AllContacts { get; set; }
    }
}
