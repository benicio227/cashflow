using CashFlow3.Communication.Requests;

namespace CashFlow3.Application.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpenseJson request);
}
