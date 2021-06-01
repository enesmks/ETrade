using System.Collections.Generic;
using Core.DataAccess;
using Core.Entitites.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
