using CashFlow3.Communication.Responses;

namespace CashFlow3.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpenseUseCase
{
    Task<ResponseExpenseJson> Execute();
}
