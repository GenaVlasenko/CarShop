using CarShop.Business.Layer.Common;
using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Services.Default
{
    public class ReviewService : IReviewsService
    {
        private readonly IReviewsRepository _reviewsRepository;
        public ReviewService(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        public IEnumerable<Reviews> GetAll()
        {
            return _reviewsRepository.GetAll();
        }
        public Result Add(Reviews review)
        {
            if (review.LinkOnVideo == null) 
            {
                return Result.Fail("LinkOnVideo is empty or has invalid chars");
            }

            if (review.Car == null || CheckBeforeWriting.HasInvalidCharacters(review.Car))
            {

                return Result.Fail("Car is empty or has invalid chars");

            }

            if (review.Image == null || CheckBeforeWriting.HasInvalidCharacters(review.Car))
            {
                return Result.Fail("Image is empty or has invalid chars");
            }

            try
            {
                _reviewsRepository.Add(review);
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }

            return Result.Ok();


        } 
        public Result Edit(Reviews review)
        {
            if (review.LinkOnVideo == null)
            {
                return Result.Fail("LinkOnVideo is empty or has invalid chars");
            }


            if (review.Car == null || CheckBeforeWriting.HasInvalidCharacters(review.Car))
            {
                return Result.Fail("Car is empty or has invalid chars");

            }

            if (review.Image == null || CheckBeforeWriting.HasInvalidCharacters(review.Image))
            {
                return Result.Fail("Image is empty or has invalid chars");

            }

            try
            {
                _reviewsRepository.Edit(review);

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
                _reviewsRepository.Delete(id);
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();


        }

    }
}
