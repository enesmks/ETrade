using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            IResult result = BusinessRules.Run(MaxOrderLimit(order.OrderId));
            if (result != null)
            {
                return result;
            }
            _orderDal.Add(order);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Order order)
        {
            IResult result = BusinessRules.Run(DeletebleNonExistingOrder());
            if (result != null)
            {
                return result;
            }
            _orderDal.Delete(order);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll());
        }

        public IDataResult<Order> GetById(int id)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(x => x.OrderId == id));
        }

        public IResult Update(Order order)
        {
            IResult result = BusinessRules.Run(UpdatebleNonExistingOrder());
            if (result != null)
            {
                return result;
            }
            _orderDal.Update(order);
            return new SuccessResult(Messages.Updated);
        }
        private IResult MaxOrderLimit(int id)
        {
            var result = _orderDal.GetAll(x => x.OrderId == id);
            if (result.Count>10)
            {
                return new ErrorResult(Messages.OrderLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult UpdatebleNonExistingOrder()
        {
            var result = _orderDal.GetAll();
            if (result.Count==0)
            {
                return new ErrorResult(Messages.UpdatebleNonExistingOrder);
            }
            return new SuccessResult();
        }
        private IResult DeletebleNonExistingOrder()
        {
            var result = _orderDal.GetAll();
            if (result.Count==0)
            {
                return new ErrorResult(Messages.DeletebleNonExistingOrder);
            }
            return new SuccessResult();
        }
    }
}
