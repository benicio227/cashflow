using CashFlow3.Communication.Requests;
using CashFlow3.Communication.Responses;

namespace CashFlow3.Application.UseCases.Expenses.Register;
public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
}
