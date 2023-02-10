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
    public class CallbackService : ICallbackService
    {
        private ICallbackRepository _callbackRepository;
        public CallbackService(ICallbackRepository callbackRepository)
        {
            _callbackRepository = callbackRepository;
        }
        public IEnumerable<Callback> GetAll()
        {
            return _callbackRepository.GetAll();
        }
        public Result Add(Callback callback)
        {
            
            if (CheckBeforeWriting.HasInvalidCharacters(callback.Name)) 
            {
                return Result.Fail("Name is empty or has invalid chars");
            }
            if (callback.Phone.Length > 17)
            {
                return Result.Fail("Phone contains more than 17 characters");
            }

            if (callback.Phone.Any(c => char.IsLetter(c)))
            {
                return Result.Fail("Phone contains letters");
            }

            try
            {
                _callbackRepository.Add(callback);
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
                _callbackRepository.Delete();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

        }

    }
}
