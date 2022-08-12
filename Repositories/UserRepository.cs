using AspNet.UnitOfWork.Data;
using AspNet.UnitOfWork.Models;

namespace AspNet.UnitOfWork.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) =>
        _context = context;

    public void Insert(User user) =>
        _context.Add(user);

}
