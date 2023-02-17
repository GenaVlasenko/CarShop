using CarShop.Business.Layer.Common;
using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using CarShop.Domain.Layer.Entities;
using FluentResults;
using System;
using System.Collections.Generic;


namespace CarShop.Business.Layer.Services.Default
{
    public class ServiceService : IService
    {

        private IServiceRepository _companyServicesRepository;
        public ServiceService(IServiceRepository companyServicesRepository)
        {
            _companyServicesRepository = companyServicesRepository;
        }
        public IEnumerable<Service> GetAll()
        {
            return _companyServicesRepository.GetAll();
        }

        public Result Add(Service services)
        {

            if (services.ServiceName == null || CheckBeforeWriting.HasInvalidCharacters(services.ServiceName))
            {
                return Result.Fail("ServiceName is empty or has invalid chars");
            }

            if (services.Description == null || CheckBeforeWriting.HasInvalidCharacters(services.Description))
            {

                return Result.Fail("Description is empty or has invalid chars");

            }
            try
            {
                _companyServicesRepository.Add(services);
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

        }

        public Result Edit(Service services)
        {
            if (services.ServiceName == null && services.Description == null)
            {
                return Result.Fail("ServiceName or Description is empty");
            }

            try
            {
                _companyServicesRepository.Edit(services);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

            return Result.Ok();


        }

        public void Delete(int id)
        {
            try
            {
                _companyServicesRepository.Delete(id);
            }
            catch(Exception ex)
            {
                Result.Fail(ex.Message);
            }
            Result.Ok();
        }

        
    }
}
