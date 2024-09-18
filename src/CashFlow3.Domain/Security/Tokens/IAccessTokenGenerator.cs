using CashFlow3.Domain.Entities;

namespace CashFlow3.Domain.Security.Tokens;
public interface IAccessTokenGenerator
{
    string Generate(User user);
}
