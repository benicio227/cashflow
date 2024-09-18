using CashFlow3.Domain.Repositories;

namespace CashFlow3.Infrastructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private readonly CashFlowDbContext _dbContext;
    
    public UnitOfWork(CashFlowDbContext dbContext) 
    { 
        _dbContext = dbContext;
    }
    public async Task Commit()
    {
       await _dbContext.SaveChangesAsync();   
    } 
}
