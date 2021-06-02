using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, ETradeContext>, IOrderDal
    {
        public List<OrderDto> GetOrderDetails()
        {
            using (var context = new ETradeContext())
            {
                var result = from order in context.Orders
                             join customer in context.Customers
                             on order.CustomerId equals customer.CustomerId
                             select new OrderDto
                             {
                                 CustomerId = customer.CustomerId,
                                 ArrivalDate = order.ArrivalDate,
                                 Fax = customer.Fax,
                                 OrderDate = order.OrderDate,
                                 OrderId = order.OrderId,
                                 Phone = customer.Phone,
                                 ShipAddress = order.ShipAddress,
                                 ShipCountry = order.ShipCountry,
                                 ShipVia = order.ShipVia,
                                 EmployeeId = order.EmployeeId
                             };
                return result.ToList();
            }
        }
    }
}
