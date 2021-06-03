using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfBankDal : EfEntityRepositoryBase<Bank,ETradeContext>,IBankDal
    {

    }
}
