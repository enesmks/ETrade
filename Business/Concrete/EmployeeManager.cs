using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll());
        }

        public IDataResult<Employee> GetById(int id)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(x => x.EmployeeId == id));
        }

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult(Messages.Updated);
        }
    }
}
