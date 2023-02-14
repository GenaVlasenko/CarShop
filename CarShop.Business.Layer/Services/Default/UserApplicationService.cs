using CarShop.Business.Layer.Common;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarShop.Business.Layer.Services.Default
{
    public class UserApplicationService : IUserApplicationService
    {
        private IUserApplicationRepository _userApplicationsRepository;
        public UserApplicationService(IUserApplicationRepository userApplicationsRepository)
        {
            _userApplicationsRepository = userApplicationsRepository;
        }
        public IEnumerable<UserApplication> GetAll()
        {
            return _userApplicationsRepository.GetAll();
        }
        public Result Add(UserApplication userApplication)
        {
            
            if (CheckBeforeWriting.HasInvalidCharacters(userApplication.Name)) 
            {
                return Result.Fail("Name is empty or has invalid chars");
            }
            if (userApplication.Phone.Length > 17)
            {
                return Result.Fail("Phone contains more than 17 characters");
            }

            if (userApplication.Phone.Any(c => char.IsLetter(c)))
            {
                return Result.Fail("Phone contains letters");
            }

            try
            {
                _userApplicationsRepository.Add(userApplication);
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);

            }
            return Result.Ok();
            

        }
        public Result Delete()
        {
            try
            {
                _userApplicationsRepository.Delete();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

        }

    }
}
