using CashFlow3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow3.Infrastructure.DataAccess;

// Para o CashFlowDbContext ser de fato um DbContext, essa minha classe precisa fazer uma herança com DbContext,
// que vem do EntityFramewordCore que instalamos

// DbSet é como uma tabela do banco de dados. Ele permite que você realize operações como inserir, atualizar,
// deletar e consultar os dados da tabela conrrespondente à entidade Expense, por isso usamos DbSet<Expense>.
// A propriedade Expenses é a que vamos usar para acessar diretamente a tabela de despesas no banco de dados
// e manioular ou acessar as despesas no banco de dados.
public class CashFlowDbContext : DbContext
{
    public CashFlowDbContext(DbContextOptions options) : base(options)
    {
    
    }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tag>().ToTable("Tags");
    }

}
