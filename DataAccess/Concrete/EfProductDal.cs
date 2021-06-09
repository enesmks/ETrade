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
        public List<ProductDetailDto> GetProductDetailDto()
        {
            using (var context = new ETradeContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryId equals category.CategoryId
                             join image in context.Images
                             on product.ProductId equals image.ImageId
                             select new ProductDetailDto
                             {
                                 CategoryName = category.CategoryName,
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName,
                                 QuantityPerUnit = product.QuantityPerUnit,
                                 UnitPrice = product.UnitPrice,
                                 UnitsInStock = product.UnitsInStock,
                                 Date=image.Date,
                                 ImagePath=image.ImagePath
                             };

                return result.ToList();

            }
        }
    }
}
