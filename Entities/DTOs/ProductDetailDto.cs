using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short QuantityPerUnit { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
