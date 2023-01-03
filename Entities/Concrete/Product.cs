using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPriceTl { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

}
