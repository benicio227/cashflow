using CashFlow3.Domain.Entities;
using CashFlow3.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace CashFlow3.Infrastructure.DataAccess.Repositories;
internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository, IUserUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbcontext;

    public UserRepository(CashFlowDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task Add(User user)
    {
        await _dbcontext.Users.AddAsync(user);  
    }

    public async Task Delete(User user)
    {
        var userToRemove = await _dbcontext.Users.FindAsync(user.Id);
        _dbcontext.Users.Remove(userToRemove!);

    }

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
       return await _dbcontext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User> GetById(long id)
    {
        return await _dbcontext.Users.FirstAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbcontext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public void Update(User user)
    {
        _dbcontext.Users.Update(user);
    }
}
