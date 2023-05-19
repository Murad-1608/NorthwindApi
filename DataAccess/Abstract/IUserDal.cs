using Core.DataAccess;
using Core.Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IRepositoryBase<User>
    {
        List<OperationClaim> GetClaims(User user);

    }
}
