using CashFlow3.Domain.Entities;

namespace CashFlow3.Domain.Repositories.Expenses;
public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> GetById(Entities.User user, long id);
    void Update(Expense expense);
}
