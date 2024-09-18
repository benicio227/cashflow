using CashFlow3.Communication.Requests;
using CashFlow3.Communication.Responses;

namespace CashFlow3.Application.UseCases.Login;
public interface IDoLoginUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}
