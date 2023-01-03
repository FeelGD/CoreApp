using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;
        private IOrderDetailDal _orderDetailDal;
        private ICustomerDal _customerDal;
        private IProductDal _productDal;

        public OrderManager(IOrderDal orderDal, ICustomerDal customerDal, IProductDal productDal, IOrderDetailDal orderDetailDal)
        {
            _orderDal = orderDal;
            _customerDal = customerDal;
            _productDal = productDal;
            _orderDetailDal = orderDetailDal;
        }
        [TransactionScopeAspect]
        public IResult Add(OrderForAddDto orderForAddDto)
        {
            IDataResult<Customer> result = /*BusinessRules.Run(CheckIfProductNameExists(product.Name),*/ CheckCustomerIdExists(orderForAddDto.CustomerId);
            if (result.Data != null)
            {
                return result;
            }

            var order = new Order
            {
                Date = DateTime.Now,
                CustomerId = orderForAddDto.CustomerId,
                CurrencyInfo= orderForAddDto.CurrencyInfo,
                NewDebt=0,
                TotalPrice=0
            };
            _orderDal.Add(order);

            foreach (var item in orderForAddDto.orderDetailsForAddDtos)
            {
                var product = _productDal.Get(p => p.Id == item.ProductId);
                var orderDetail = new OrderDetail
                {
                    OrderId = order.Id,
                    ProductId=item.ProductId,
                    Quantity=item.Quantity,
                    UnitPrice=product.UnitPrice,
                    TotalPrice=(product.UnitPrice*item.Quantity)
                };
                order.TotalPrice += orderDetail.TotalPrice;
                _orderDetailDal.Add(orderDetail);
             }

            order.NewDebt = result.Data.Debt + order.TotalPrice;
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderAdded);

        }
        private IDataResult<Customer> CheckCustomerIdExists(int customerId)
        {

            var result = _customerDal.Get(c=>c.Id==customerId);
            if (result==null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<Customer>(result);
        }

        public IDataResult<OrderDetailsDto> GetByOrderId(int orderId)
        {
            var result = _orderDal.GetDetails(orderId);
            if (result!=null)
            {
                return new SuccessDataResult<OrderDetailsDto>(result);
            }
            return new ErrorDataResult<OrderDetailsDto>(Messages.PleaseContactManager);
        }

        public IDataResult<List<Order>> GetList()
        {
           return new SuccessDataResult<List<Order>>(_orderDal.GetList().ToList());
        }
        
    }
}
