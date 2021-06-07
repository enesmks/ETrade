using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;

        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public IResult Add(SubCategory subCategory)
        {
            _subCategoryDal.Add(subCategory);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(SubCategory subCategory)
        {
            _subCategoryDal.Delete(subCategory);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<SubCategory>> GetAll()
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll());
        }

        public IDataResult<List<SubCategory>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<SubCategory>>(_subCategoryDal.GetAll(x => x.CategoryId == id));
        }

        public IDataResult<SubCategory> GetById(int id)
        {
            return new SuccessDataResult<SubCategory>(_subCategoryDal.Get(x => x.SubCategoryId == id));
        }

        [TransactionScopeAspect]
        public IResult TransactinalOperation(SubCategory subCategory)
        {
            _subCategoryDal.Add(subCategory);
            _subCategoryDal.Delete(subCategory);
            return new SuccessResult();
        }

        public IResult Update(SubCategory subCategory)
        {
            _subCategoryDal.Update(subCategory);
            return new SuccessResult(Messages.Updated);
        }
    }
}
