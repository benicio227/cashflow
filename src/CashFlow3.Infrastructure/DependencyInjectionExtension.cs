using CashFlow3.Domain.Repositories;
using CashFlow3.Domain.Repositories.Expenses;
using CashFlow3.Domain.Repositories.User;
using CashFlow3.Domain.Security.Cryptography;
using CashFlow3.Domain.Security.Tokens;
using CashFlow3.Domain.Services.LoggedUser;
using CashFlow3.Infrastructure.DataAccess;
using CashFlow3.Infrastructure.DataAccess.Repositories;
using CashFlow3.Infrastructure.Extensions;
using CashFlow3.Infrastructure.Security.Tokens;
using CashFlow3.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow3.Infrastructure;

// A classe DependencyInjectionExtension é usada para organizar e centralizar a configuração de injeção de depen
// dência na sua aplicação. Ela ajuda a manter o código limpo e modular ao fornecer um local único para registrar
// as dependências da camada de Infraestrutura do projeto.

// A classe DependencyInjectionExtension é estática, o que significa que ela não pode ser instanciada.

// A interface IServiceCollection é usada para configurar injeção de dependência.
// O AddScoped indica que para cada requisição HTTP, uma nova instância de ExpensesRepository será criada e usada.
// Após o término da requisição, essa instância será descartada.
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
        services.AddScoped<ILoggedUser, LoggedUser>();

        AddToken(services, configuration);
        AddRepositories(services);

        if (configuration.IsTestEnvironment() == false)
        {
            AddDbContext(services, configuration);
        }



    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigninKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
    }
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 39);
        var serverVersion = new MySqlServerVersion(version);

        //optionsBuilder.UseMySql(connectionString, serverVersoin);

        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString,serverVersion));
    }
}
