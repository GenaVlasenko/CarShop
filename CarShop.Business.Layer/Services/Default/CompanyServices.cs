using CarShop.Business.Layer.Common;
using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;


namespace CarShop.Business.Layer.Services.Default
{
    public class CompanyServices : ICompanyServices
    {

        private ICompanyServicesRepository _companyServicesRepository;
        public CompanyServices(ICompanyServicesRepository companyServicesRepository)
        {
            _companyServicesRepository = companyServicesRepository;
        }
        public IEnumerable<CompanyService> GetAll()
        {
            return _companyServicesRepository.GetAll();
        }

        public Result Add(CompanyService services)
        {


            return Result.Ok();

        }

        public Result Edit(CompanyService services)
        {
            if (services.Auction == null || CheckBeforeWriting.HasInvalidCharacters(services.Auction))
            {
                return Result.Fail("Auction is empty or has invalid chars");
            }

            if (services.DeliveryUSA == null || CheckBeforeWriting.HasInvalidCharacters(services.DeliveryUSA))
            {
                return Result.Fail("DeliveryUSA is empty or has invalid chars");
            }

            if (services.DeliveryUSA_Ukraine == null || CheckBeforeWriting.HasInvalidCharacters(services.DeliveryUSA_Ukraine))
            {
                return Result.Fail("Delivery USA-Ukraine is empty or has invalid chars");
            }

            if (services.Customs_Clearance == null || CheckBeforeWriting.HasInvalidCharacters(services.Customs_Clearance))
            {
                return Result.Fail("Color is empty or has invalid chars");
            }

            if (services.Delivery_InCity == null || CheckBeforeWriting.HasInvalidCharacters(services.Delivery_InCity))
            {
                return Result.Fail("Delivery InCity is empty or has invalid chars");
            }

            if (services.Repairy == null || CheckBeforeWriting.HasInvalidCharacters(services.Repairy))
            {
                return Result.Fail("Repairy is empty or has invalid chars");
            }

            if (services.Registration == null || CheckBeforeWriting.HasInvalidCharacters(services.Registration))
            {
                return Result.Fail("Registration is empty or has invalid chars");
            }

            if (services.Detailing == null || CheckBeforeWriting.HasInvalidCharacters(services.Detailing))
            {
                return Result.Fail("Detailing is empty or has invalid chars");
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
