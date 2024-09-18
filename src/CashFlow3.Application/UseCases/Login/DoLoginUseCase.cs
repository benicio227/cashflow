using CashFlow3.Communication.Requests;
using CashFlow3.Communication.Responses;
using CashFlow3.Domain.Repositories.User;
using CashFlow3.Domain.Security.Cryptography;
using CashFlow3.Domain.Security.Tokens;
using CashFlow3.Exception.ExceptionsBase;

namespace CashFlow3.Application.UseCases.Login;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(
        IUserReadOnlyRepository repository,
        IPasswordEncripter passwordEncripter,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _passwordEncripter = passwordEncripter;
        _repository = repository;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if(user is null)
        {
            throw new InvalidLoginException();
        };

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if(passwordMatch == false)
        {
            throw new InvalidLoginException();
        };

        return new ResponseRegisteredUserJson
        {
            Name = user.Name,
            Token = _accessTokenGenerator.Generate(user)
        };
    }
}
