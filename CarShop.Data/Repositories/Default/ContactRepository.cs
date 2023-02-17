using CarShop.Data.Layer.Common;
using CarShop.Domain.Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarShop.Data.Layer.Repositories.Default
{
    public class ContactRepository : IContactRepository
    {
        
        private DatabaseConnection _databaseConnection;
        public ContactRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public IEnumerable<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            SqlDataReader sqlDataReader = _databaseConnection.Connection("Select * from Contacts");
            while (sqlDataReader.Read())
            {
                contacts.Add(new Contact()
                {
                    Id = Convert.ToInt32(sqlDataReader[0]),
                    City = sqlDataReader[1].ToString(),
                    Phone = sqlDataReader[2].ToString()
                });
            }
            _databaseConnection.connection.Close();
            return contacts;
        }

        public void Add(Contact contact)
        {
            _databaseConnection.Connection("Insert into Contacts (Місто, Телефон) " +
                 $"Values ('{contact.City}', '{contact.Phone}')");
            _databaseConnection.connection.Close();

        }

        public void Edit(Contact contact)
        {
            _databaseConnection.Connection($"Update Contacts Set City = '{contact.City}'");
            _databaseConnection.connection.Close();

        }

        public void Delete(int id)
        {
            _databaseConnection.Connection($"Delete Contacts Where id = {id}");
            _databaseConnection.connection.Close();

        }
    }
}
