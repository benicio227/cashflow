using CashFlow3.Communication.Requests;

namespace CashFlow3.Application.UseCases.Users.ChangePassword;
public interface IChangePasswordUseCase
{
    Task Execute(RequestChangePasswordJson request);
}
