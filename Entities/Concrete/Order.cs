using Core.Entitites;
using System;

namespace Entities.Concrete
{
    public class Order : IEntity
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
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
