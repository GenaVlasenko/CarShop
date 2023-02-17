using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;


namespace CarShop.Business.Layer.Services.Default
{
    public class CarDetailService: ICarDetailService
    {
        private ICarDetailRepository _carsDetailsRepository;
        public CarDetailService(ICarDetailRepository carsDetailsRepository)
        {
            _carsDetailsRepository = carsDetailsRepository;


        }
        public IEnumerable<CarDetail> GetAll()
        {
            return _carsDetailsRepository.GetAll();
        }
        public Result Add(CarDetail carsdetails)
        {
            if(carsdetails.Video == null)
            {
                return Result.Fail("Video is empty");
            }
            if (carsdetails.First_photo == null)
            {
                return Result.Fail("First photo is empty");
            }
            if (carsdetails.Second_photo == null)
            {
                return Result.Fail("Second photo photo is empty");
            }
            if (carsdetails.Third_photo == null)
            {
                return Result.Fail("Third photo photo photo is empty");
            }
            if (carsdetails.Four_photo == null)
            {
                return Result.Fail("Four photo photo photo is empty");
            }

            try
            {
                _carsDetailsRepository.Add(carsdetails);
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

        }
    }
}
