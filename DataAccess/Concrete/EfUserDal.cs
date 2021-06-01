using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System.Linq;
using System.Collections.Generic;
using Core.Entitites.Concrete;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, ETradeContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ETradeContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim
                             {
                                 OperationClaimId = operationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
