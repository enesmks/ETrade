using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,ETradeContext>,ICategoryDal
    {
    }
}
