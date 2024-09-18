using CashFlow3.Domain.Entities;

namespace CashFlow3.Domain.Services.LoggedUser;
public interface ILoggedUser
{
    Task<User> Get();
}
