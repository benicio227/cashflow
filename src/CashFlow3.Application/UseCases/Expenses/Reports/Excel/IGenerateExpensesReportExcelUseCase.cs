namespace CashFlow3.Application.UseCases.Expenses.Reports.Excel;
public interface IGenerateExpensesReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
