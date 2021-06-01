using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ETradeContext>, IProductDal
    {
        public List<ProductDto> GetproductDetails()
        {
            using (var context = new ETradeContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryId equals category.CategoryId
                             join supplier in context.Suppliers
                             on product.SupplierId equals supplier.SupplierId
                             select new ProductDto
                             {
                                 Address = supplier.Address,
                                 CategoryId = category.CategoryId,
                                 CategoryName = category.CategoryName,
                                 City = supplier.City,
                                 CompanyName = supplier.CompanyName,
                                 Country = supplier.Country,
                                 Fax = supplier.Fax,
                                 Phone = supplier.Phone,
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName,
                                 QuantityPerUnit = product.QuantityPerUnit,
                                 SupplierId = supplier.SupplierId,
                                 UnitPrice = product.UnitPrice,
                                 UnitsInStock = product.UnitsInStock
                             };
                return result.ToList();
                             
            }
        }
    }
}
