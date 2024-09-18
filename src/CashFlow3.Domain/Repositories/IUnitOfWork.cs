namespace CashFlow3.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
