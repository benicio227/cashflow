using CashFlow3.Communication.Responses;

namespace CashFlow3.Application.UseCases.Expenses.Delete;
public interface IDeleteExpenseUseCase
{
    Task Execute(long id);
}
 