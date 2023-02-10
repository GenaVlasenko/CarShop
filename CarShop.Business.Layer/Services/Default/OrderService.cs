using CarShop.Business.Layer.Common;
using CarShop.Business.Layer.Serveces;
using CarShop.Data.Layer.Repositories;
using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Services.Default
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<Order> GetAll()
        {

            return _orderRepository.GetAll();

        }
        public Result Add(Order order)
        { 

            if (order.FirstName == null || CheckBeforeWriting.HasInvalidCharacters(order.FirstName))
            {

                return Result.Fail("FirstName is empty or has invalid chars");

            }

            if (order.LastName == null || CheckBeforeWriting.HasInvalidCharacters(order.LastName))
            {

                return Result.Fail("LastName is empty or has invalid chars");

            }

            if (order.Phone == null || CheckBeforeWriting.HasInvalidCharacters(order.Phone))
            {

                return Result.Fail("Phone is empty or has invalid chars");

            }

            if (order.Email == null || CheckBeforeWriting.HasInvalidCharacters(order.Email))
            {

                return Result.Fail("Email is empty or has invalid chars");

            }

            if (order.City == null || CheckBeforeWriting.HasInvalidCharacters(order.City))
            {

                return Result.Fail("City is empty or has invalid chars");

            }

            try
            {
                _orderRepository.Add(order);

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
                _orderRepository.Delete();
            }
            catch(Exception ex)
            {
                return Result.Fail(ex.Message);
            }
            return Result.Ok();

            
        }

    }
}
