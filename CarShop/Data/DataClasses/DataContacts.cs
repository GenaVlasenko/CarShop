using CarShop.Data.Interfaces;
using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarShop.Data.Mocks
{
    public class DataContacts : IContacts
    {
        public IEnumerable<Contacts> AllContacts { get; set; }
        DatabaseConnection databaseConnection;
        SqlDataReader sqlDataReader;
        CheckBeforeWriting checkBefore;
        List<Contacts> contacts;
        string empty = " поле пусте містить спецсимволи";
        string warning = " містить спецсимволи";

        public DataContacts()
        {
            databaseConnection = new DatabaseConnection();
            AllContacts = GetAllContacts();
        }
        public IEnumerable<Contacts> GetAllContacts()
        {
            contacts = new List<Contacts>();
            sqlDataReader = databaseConnection.Connection("Select * from Contacts");
            while (sqlDataReader.Read())
            {
                contacts.Add( new Contacts()
                {
                    id = Convert.ToInt32(sqlDataReader[0]),
                    city = sqlDataReader[1].ToString(), 
                    phone = sqlDataReader[2].ToString()
                });
            }
            databaseConnection.connection.Close();
            return contacts;
        }
        public string AddContact(Contacts contacts)
        {
            checkBefore = new CheckBeforeWriting();
            if (contacts.id != 0)
            {
                if (checkBefore.Special_Characters(contacts.city)) { }
                else { return $"Поле Місто" + warning; }
            }
            else { return $"{contacts.city}" + empty; }

            if (contacts.phone != null) { }

            else { return $"Поле Телефон" + empty; }
            try
            {
                databaseConnection.Connection("Insert into Contacts (Місто, Телефон) " +
                 $"Values ('{contacts.city}', '{contacts.phone}')");

            }
            catch
            {
                databaseConnection.connection.Close();
                return "Сталася помилка при записі контакту";
            }
            databaseConnection.connection.Close();
            return "Дані успішно записані";

            
        }   
        public string EditContact(Contacts contacts)
        {
            CheckBeforeWriting checkBeforeWriting = new CheckBeforeWriting();
            if (this.contacts.Select(x=>x.id).Contains(contacts.id))
            {
                checkBefore = new CheckBeforeWriting();
                string comand = "Update Contacts Set ";
                if (contacts.id != 0)
                {
                    if (checkBefore.Special_Characters(Convert.ToString(contacts.id))) { }

                    else
                    {
                        return $"Поле Місто" + warning;
                    }

                }

                if (contacts.city != null)
                {
                    if (checkBefore.Special_Characters(contacts.city))
                    {
                        comand += $"Місто = '{contacts.city}', ";
                    }
                    else
                    {
                        return $"Місто" + warning;
                    }

                }
                //else
                //{
                //    return $"{contacts.city}" + empty;
                //}

                if (contacts.phone != null)
                {
                    comand += $"Телефон = '{contacts.phone}', ";

                }
                //else
                //{
                //    return $"Поле телефон" + empty;
                //}

                comand = comand.Substring(0, comand.Length - 2);
                comand += $" Where id = {contacts.id}";
                try
                {
                    databaseConnection.Connection(comand);
                }
                catch
                {
                    databaseConnection.connection.Close();
                    return "Сталася помилка при редагуванні контакту";
                }
                databaseConnection.connection.Close();
                return "Контакт успішно змінений";

            }
            else
            {
                databaseConnection.connection.Close();
                return "Введенний id некорректний";
            }
           
        }  
        public string DeleteContact(int id)
        {
            
            checkBefore = new CheckBeforeWriting();
            if(this.contacts.Select(x => x.id).Contains(id))
            {
                if (checkBefore.Special_Characters(Convert.ToString(id)))
                {
                    try
                    {
                        databaseConnection.Connection($"Delete Contacts Where id = {id}");
                    }
                    catch
                    {
                        return "Невірно вказаний ідентифікатор";
                    }
                    databaseConnection.connection.Close();
                    return "Операція прошла успішно";
                }
                else
                {
                    databaseConnection.connection.Close();
                    return $"Id" + warning;
                }

            }
            else
            {
                databaseConnection.connection.Close();
                return "Введенний id некорректний";
            }
            



        }

        
    }
}
