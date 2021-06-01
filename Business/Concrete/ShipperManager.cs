using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ShipperManager : IShipperService
    {
        IShipperDal _shipperDal;

        public ShipperManager(IShipperDal shipperDal)
        {
            _shipperDal = shipperDal;
        }

        public IResult Add(Shipper shipper)
        {
            _shipperDal.Add(shipper);
            return new ErrorResult(Messages.Added);
        }

        public IResult Delete(Shipper shipper)
        {
            _shipperDal.Delete(shipper);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Shipper>> GetAll()
        {
            return new SuccessDataResult<List<Shipper>>(_shipperDal.GetAll());
        }

        public IDataResult<Shipper> GetById(int id)
        {
            return new SuccessDataResult<Shipper>(_shipperDal.Get(x => x.ShipperId == id));
        }

        public IResult Update(Shipper shipper)
        {
            _shipperDal.Update(shipper);
            return new SuccessResult(Messages.Updated);
        }
    }
}
