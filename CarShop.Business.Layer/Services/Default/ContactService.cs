using CarShop.Business.Layer.Common;
using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Services.Default
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactService(IContactRepository contactsRepository)
        {
            _contactRepository = contactsRepository;
        }
        public IEnumerable<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }
        public Result Add(Contact contact)
        {
            
            if (contact.City == null || CheckBeforeWriting.HasInvalidCharacters(contact.City))
            {
                return Result.Fail("City is empty or has invalid chars");
            }
            

            if (contact.Phone == null) 
            {
                return Result.Fail("Phone is empty or has invalid chars");
            }

            
            try
            {
                _contactRepository.Add(contact);

            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

            
        }   
        public Result Edit(Contact contact)
        {
            if (contact.Id == 0)
            {
                return Result.Fail("id is 0");

            }

            if (contact.City == null || CheckBeforeWriting.HasInvalidCharacters(contact.City))
            {
                return Result.Fail("City is empty or has invalid chars");

            }

            if (contact.Phone == null || CheckBeforeWriting.HasInvalidCharacters(contact.Phone))
            {
                return Result.Fail("Phone is empty or has invalid chars");

            }

            try
            {
                _contactRepository.Edit(contact);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

        }
        public Result Delete(int id) 
        {
            try
            {
                _contactRepository.Delete(id);
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

        }
    }
}
