using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderForAddDto : IDto
    {
        public int CustomerId { get; set; }
        public decimal CurrencyInfo { get; set; }
        public List<OrderDetailsForAddDto> orderDetailsForAddDtos { get; set; }

    }
    public class OrderDetailsForAddDto : IDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
