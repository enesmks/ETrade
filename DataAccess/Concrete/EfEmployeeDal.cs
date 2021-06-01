using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, ETradeContext>, IEmployeeDal
    {

    }
}
