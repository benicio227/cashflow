using CashFlow3.Application.AutoMapper;
using CashFlow3.Application.UseCases.Expenses.Delete;
using CashFlow3.Application.UseCases.Expenses.GetAll;
using CashFlow3.Application.UseCases.Expenses.GetById;
using CashFlow3.Application.UseCases.Expenses.Register;
using CashFlow3.Application.UseCases.Expenses.Reports.Excel;
using CashFlow3.Application.UseCases.Expenses.Update;
using CashFlow3.Application.UseCases.Login;
using CashFlow3.Application.UseCases.Users.ChangePassword;
using CashFlow3.Application.UseCases.Users.Delete;
using CashFlow3.Application.UseCases.Users.Profile;
using CashFlow3.Application.UseCases.Users.Register;
using CashFlow3.Application.UseCases.Users.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow3.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
        services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        services.AddScoped<IDeleteUserAccountUseCase, DeleteUserAccountUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
    }
}
