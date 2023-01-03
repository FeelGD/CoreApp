using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, CoreContext>, IOrderDal
    {
        public OrderDetailsDto GetDetails(int orderId)
        {
            using (var context = new CoreContext())
            {


                var result = from order in context.Orders

                             where order.Id == orderId
                             select new OrderDetailsDto
                             {
                                 Id = orderId,
                                 CurrencyInfo = order.CurrencyInfo,
                                 CustomerId = order.CustomerId,
                                 Date = order.Date,
                                 NewDebt = order.NewDebt,
                                 TotalPrice = order.TotalPrice,
                                 OrderDetails = (from orderDetail in context.OrderDetails
                                                 join product in context.Products
                                                    on orderDetail.ProductId equals product.Id
                                                 where orderDetail.OrderId == orderId
                                                 select new OrderDetailDto
                                                 {
                                                    Id=orderDetail.Id,
                                                    ProductName= product.QuantityPerUnit+" "+product.Name,
                                                    UnitPrice=orderDetail.UnitPrice,
                                                    Quantity=orderDetail.Quantity,
                                                    TotalPrice=orderDetail.TotalPrice
                                                 }).ToList()

                             };
                return result.SingleOrDefault();

            }
        }

    }
}
