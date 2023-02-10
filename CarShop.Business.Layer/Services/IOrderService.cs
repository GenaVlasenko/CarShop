using CarShop.Domain.Layer;
using FluentResults;
using System;
using System.Collections.Generic;

namespace CarShop.Business.Layer.Serveces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Result Add(Order order);
        Result Delete();
    }
}
