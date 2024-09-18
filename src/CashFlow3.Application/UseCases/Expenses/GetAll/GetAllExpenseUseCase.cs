﻿using AutoMapper;
using CashFlow3.Communication.Responses;
using CashFlow3.Domain.Repositories.Expenses;
using CashFlow3.Domain.Services.LoggedUser;

namespace CashFlow3.Application.UseCases.Expenses.GetAll;
public class GetAllExpenseUseCase : IGetAllExpenseUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public GetAllExpenseUseCase(IExpensesReadOnlyRepository repository,
        IMapper mapper,
        ILoggedUser loggedUser)
    {
        _repository = repository;
        _mapper = mapper;
        _loggedUser = loggedUser;

    }
    public async Task<ResponseExpenseJson> Execute()
    {
        var loggedUser = await _loggedUser.Get();

        var result = await _repository.GetAll(loggedUser);

        return new ResponseExpenseJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }

}
