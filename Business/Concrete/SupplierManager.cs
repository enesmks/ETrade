using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        [ValidationAspect(typeof(SupplierValidator))]
        [SecuredOperation("admin,customer")]
        [CacheRemoveAspect("ISupplierService.Get")]
        public IResult Add(Supplier supplier)
        {
            _supplierDal.Add(supplier);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin,customer")]
        public IResult Delete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Supplier>> GetAll()
        {
            return new SuccessDataResult<List<Supplier>>(_supplierDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Supplier> GetById(int id)
        {
            return new SuccessDataResult<Supplier>(_supplierDal.Get(x => x.SupplierId == id));
        }

        [TransactionScopeAspect]
        public IResult TransactinalOperation(Supplier supplier)
        {
            _supplierDal.Add(supplier);
            _supplierDal.Update(supplier);
            return new SuccessResult();
        }

        [SecuredOperation("admin,customer")]
        public IResult Update(Supplier supplier)
        {
            _supplierDal.Update(supplier);
            return new SuccessResult(Messages.Updated);
        }
    }
}
