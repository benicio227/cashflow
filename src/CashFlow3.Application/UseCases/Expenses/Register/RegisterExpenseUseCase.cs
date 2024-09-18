using AutoMapper;
using CashFlow3.Communication.Requests;
using CashFlow3.Communication.Responses;
using CashFlow3.Domain.Entities;
using CashFlow3.Domain.Repositories;
using CashFlow3.Domain.Repositories.Expenses;
using CashFlow3.Domain.Services.LoggedUser;
using CashFlow3.Exception.ExceptionsBase;

namespace CashFlow3.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;
    public RegisterExpenseUseCase(
        IExpensesWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILoggedUser loggedUser)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        // O entity é simplesmente um objeto "Expense" que você está preenchendo com os  dados recebidos na requi
        // sição "request". Após isso, você adiciona esse "entity" ao contexto "dbContext.Expenses.Add(entity);"
        // que postteriormente será salvo no banco de dados.
        var loggededUser = await _loggedUser.Get();

        var expense = _mapper.Map<Expense>(request);
        expense.UserId = loggededUser.Id;

        await _repository.Add(expense);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredExpenseJson>(expense);
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();
       
        //result: Esse é um objeto do tipo ValidationResult, retornado pelo método "Validate" do FluentValidation.
        //ValidationResult: Esse objeto contém o resultado da validação, e uma das propriedades mais importantes
        //dele é a propriedade "Errors".
        //Errors: é uma lista de objetos do tipo "ValidationFailure". Se a validação falhar, essa lista será pree
        //nchida, com um ou mais objetos "ValidationFailure", onde cada objeto representa uma regra de validação
        //que falhou.
        //ValidationFailure: Esse objeto contem detalhes sobre a falha de validação. Algumas de suas propriedades
        //são: ErrorMessage(a mensagem de erro descrevendo o que deu de errado na validação)
        var result = validator.Validate(request);

        //Cada falha em uma regra de validação resulta em uma instância de ValidationFailure,
        //que é então coletada em uma lista (Errors) dentro de um objeto ValidationResult.

        //Se você usar ToList(), você força a avaliação imediata da sequência, criando uma lista concreta
        //(List<string>) em memória, que você pode acessar e manipular diretamente.

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
