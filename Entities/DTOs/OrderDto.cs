using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDto : IDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCountry { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int ShipVia { get; set; }
    }
}
