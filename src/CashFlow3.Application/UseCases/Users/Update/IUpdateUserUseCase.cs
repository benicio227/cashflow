using CashFlow3.Communication.Requests;

namespace CashFlow3.Application.UseCases.Users.Update;
public interface IUpdateUserUseCase
{
    Task Execute(RequestUpdateUserJson request);
}
