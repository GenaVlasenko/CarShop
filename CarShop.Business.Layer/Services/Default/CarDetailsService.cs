using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;


namespace CarShop.Business.Layer.Services.Default
{
    public class CarDetailsService: ICarsDetailsService
    {
        private ICarsDetailsRepository _carsDetailsRepository;
        public CarDetailsService(ICarsDetailsRepository carsDetailsRepository)
        {
            _carsDetailsRepository = carsDetailsRepository;


        }
        public IEnumerable<CarDetails> GetAll()
        {
            return _carsDetailsRepository.GetAll();
        }
        public Result Add(CarDetails carsdetails)
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
