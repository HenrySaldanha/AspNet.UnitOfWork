using AspNet.UnitOfWork.Models;

namespace AspNet.UnitOfWork.Repositories;

internal interface IUserRepository
{
    public void Insert(User user);
}
