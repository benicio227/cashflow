using CashFlow3.Communication.Responses;

namespace CashFlow3.Application.UseCases.Users.Profile;
public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
