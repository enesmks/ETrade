using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Supplier supplier)
        {
            _supplierDal.Add(supplier);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Supplier>> GetAll()
        {
            return new SuccessDataResult<List<Supplier>>(_supplierDal.GetAll());
        }

        public IDataResult<Supplier> GetById(int id)
        {
            return new SuccessDataResult<Supplier>(_supplierDal.Get(x => x.SupplierId == id));
        }

        public IResult Update(Supplier supplier)
        {
            _supplierDal.Update(supplier);
            return new SuccessResult(Messages.Updated);
        }
    }
}
