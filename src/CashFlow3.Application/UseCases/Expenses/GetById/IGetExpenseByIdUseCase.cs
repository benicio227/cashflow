using CashFlow3.Communication.Responses;

namespace CashFlow3.Application.UseCases.Expenses.GetById;
public interface IGetExpenseByIdUseCase
{
    Task<ResponsesExpenseJson> Execute(long id);
}
