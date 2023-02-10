using CarShop.Business.Layer.Common;
using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Services.Default
{
    internal class CarService : ICarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Car> GetAll()
        {
            return _repository.GetAll();
        } 

        public Result Add(Car addcar)
        {
            if (addcar.CarName == null || CheckBeforeWriting.HasInvalidCharacters(addcar.CarName))
            {
                return Result.Fail("CarName is empty or has invalid chars");
            }

            if (addcar.Model == null || CheckBeforeWriting.HasInvalidCharacters(addcar.Model))
            {
                return Result.Fail("Model is empty or has invalid chars");
            }

            if (addcar.Year == null || CheckBeforeWriting.HasInvalidCharacters(addcar.Year))
            {
                return Result.Fail("Year is empty or has invalid chars");
            }

            if (addcar.Color == null || CheckBeforeWriting.HasInvalidCharacters(addcar.Color))
            {
                return Result.Fail("Color is empty or has invalid chars");
            }

            if (addcar.Engine == null || CheckBeforeWriting.HasInvalidCharacters(addcar.Engine))
            {
                return Result.Fail("Engine is empty or has invalid chars");
            }

            if (addcar.TypeofCar == null || CheckBeforeWriting.HasInvalidCharacters(addcar.TypeofCar))
            {
                return Result.Fail("TypeofCar is empty or has invalid chars");
            }

            if (addcar.Transmission == null || CheckBeforeWriting.HasInvalidCharacters(addcar.Transmission))
            {
                return Result.Fail("Transmission is empty or has invalid chars");
            }

            if (addcar.Mileage == null || CheckBeforeWriting.HasInvalidCharacters(addcar.Mileage))
            {
                return Result.Fail("Mileage is empty or has invalid chars");
            }

            if (addcar.CarAccident == null || CheckBeforeWriting.HasInvalidCharacters(addcar.CarAccident))
            {
                return Result.Fail("CarAccident is empty or has invalid chars");
            }

            if (addcar.CarInStock == null || CheckBeforeWriting.HasInvalidCharacters(addcar.CarInStock))
            {
                return Result.Fail("CarInStock is empty or has invalid chars");
            }

            if (addcar.Price <= 0)
            {
                return Result.Fail("Price is empty");
            }

            try
            {
                _repository.Add(addcar);
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
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

            return Result.Ok();
        }

        public Result Edit(Car editcar)
        {
            if (editcar.CarName == null || CheckBeforeWriting.HasInvalidCharacters(editcar.CarName))
            {
                return Result.Fail("CarName is empty or has invalid chars");
            }

            if (editcar.Model == null || CheckBeforeWriting.HasInvalidCharacters(editcar.Model))
            {
                return Result.Fail("Model is empty or has invalid chars");
            }

            if (editcar.Year == null || CheckBeforeWriting.HasInvalidCharacters(editcar.Year))
            {
                return Result.Fail("Year is empty or has invalid chars");
            }

            if (editcar.Color == null || CheckBeforeWriting.HasInvalidCharacters(editcar.Color))
            {
                return Result.Fail("Color is empty or has invalid chars");
            }

            if (editcar.Engine == null || CheckBeforeWriting.HasInvalidCharacters(editcar.Engine))
            {
                return Result.Fail("Engine is empty or has invalid chars");
            }

            if (editcar.TypeofCar == null || CheckBeforeWriting.HasInvalidCharacters(editcar.TypeofCar))
            {
                return Result.Fail("TypeofCar is empty or has invalid chars");
            }

            if (editcar.Transmission == null || CheckBeforeWriting.HasInvalidCharacters(editcar.Transmission))
            {
                return Result.Fail("Transmission is empty or has invalid chars");
            }

            if (editcar.Mileage == null || CheckBeforeWriting.HasInvalidCharacters(editcar.Mileage))
            {
                return Result.Fail("Mileage is empty or has invalid chars");
            }

            if (editcar.CarAccident == null || CheckBeforeWriting.HasInvalidCharacters(editcar.CarAccident))
            {
                return Result.Fail("CarAccident is empty or has invalid chars");
            }

            if (editcar.CarInStock == null || CheckBeforeWriting.HasInvalidCharacters(editcar.CarInStock))
            {
                return Result.Fail("CarInStock is empty or has invalid chars");
            }

            try
            {
                _repository.Edit(editcar);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

            return Result.Ok();
        }

        
    }
}
