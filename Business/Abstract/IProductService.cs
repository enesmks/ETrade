using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService : ICrudService<Product>
    {
        IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}
