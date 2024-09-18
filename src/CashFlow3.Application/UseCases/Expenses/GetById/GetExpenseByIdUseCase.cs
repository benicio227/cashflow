using AutoMapper;
using CashFlow3.Communication.Responses;
using CashFlow3.Domain.Repositories.Expenses;
using CashFlow3.Domain.Services.LoggedUser;
using CashFlow3.Exception;
using CashFlow3.Exception.ExceptionsBase;

namespace CashFlow3.Application.UseCases.Expenses.GetById;
public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository,
        IMapper mapper,
        ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;   
    }

    public async Task<ResponsesExpenseJson> Execute(long id)
    {
        var loggedUser = await _loggedUser.Get();

        var result = await _repository.GetById(loggedUser, id);

        if (result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponsesExpenseJson>(result);
    }
}
