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
            string comand = "Update Contacts Set ";

            if (contact.City != null)
            {
                comand += $"Місто = '{contact.City}', ";
            }

            if (contact.Phone != null)
            {
                comand += $"Телефон = '{contact.Phone}', ";

            }

            comand = comand.Substring(0, comand.Length - 2);
            comand += $" Where id = {contact.Id}";
            _databaseConnection.Connection(comand);
            _databaseConnection.connection.Close();

        }

        public void Delete(int id)
        {
            _databaseConnection.Connection($"Delete Contacts Where id = {id}");
            _databaseConnection.connection.Close();

        }
    }
}
