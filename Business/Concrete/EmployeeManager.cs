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
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        [ValidationAspect(typeof(EmployeeValidator))]
        [SecuredOperation("admin,customer")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin,customer")]
        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Employee> GetById(int id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(x => x.EmployeeId == id));
        }

        [TransactionScopeAspect]
        public IResult TransactinalOperation(Employee employee)
        {
            _employeeDal.Add(employee);
            _employeeDal.Update(employee);
            return new SuccessResult();
        }

        [SecuredOperation("admin,customer")]
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.Updated);
        }
    }
}
