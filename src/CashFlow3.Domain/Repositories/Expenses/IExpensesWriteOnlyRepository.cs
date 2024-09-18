using CashFlow3.Domain.Entities;

namespace CashFlow3.Domain.Repositories.Expenses;
public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
 
    Task Delete(long id);
}
