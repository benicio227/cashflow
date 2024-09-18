using CashFlow3.Communication.Requests;
using CashFlow3.Communication.Responses;

namespace CashFlow3.Application.UseCases.Users.Register;
public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
