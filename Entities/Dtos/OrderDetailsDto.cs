using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class OrderDetailsDto:IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal CurrencyInfo { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal NewDebt { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
