using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [ValidationAspect(typeof(ProductValidator))]
        [SecuredOperation("admin,customer")]
        [CacheRemoveAspect("IProductService.Get")]
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

        [SecuredOperation("admin,customer")]
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

        [CacheAspect]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == id));
        }

        [SecuredOperation("admin,customer")]
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

        [TransactionScopeAspect]
        public IResult TransactinalOperation(Product product)
        {
            _productDal.Add(product);
            _productDal.Update(product);
            return new SuccessResult();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDto());
        }
    }
}
