using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckNumberOfProduct(product.ProductId),CheckIfProductCountOfCategoryCorrect(product.CategoryId));
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Product product)
        {
            IResult result = BusinessRules.Run(DeletebleNonExistingOrder());
            if (result != null)
            {
                return result;
            }
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == id));
        }

        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(UpdatebleNonExistingProduct());
            if (result != null)
            {
                return result;
            }
            _productDal.Update(product);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckNumberOfProduct(int productId)
        {
            var result = _productDal.GetAll(x=>x.ProductId==productId);
            if (result.Count>15)
            {
                return new ErrorResult(Messages.ProductLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(x => x.CategoryId == categoryId);
            if (result.Count>10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult UpdatebleNonExistingProduct()
        {
            var result = _productDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorResult(Messages.UpdatebleNonExistingProduct);
            }
            return new SuccessResult();
        }
        private IResult DeletebleNonExistingOrder()
        {
            var result = _productDal.GetAll();
            if (result.Count == 0)
            {
                return new ErrorResult(Messages.DeletebleNonExistingProduct);
            }
            return new SuccessResult();
        }
    }
}
