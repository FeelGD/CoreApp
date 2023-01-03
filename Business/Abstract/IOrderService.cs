using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<OrderDetailsDto> GetByOrderId(int orderId);
        IDataResult<List<Order>> GetList();

        IResult Add(OrderForAddDto orderForAddDto);

    }
}
