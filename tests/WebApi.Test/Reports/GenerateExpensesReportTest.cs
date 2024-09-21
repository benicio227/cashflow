﻿using FluentAssertions;
using System.Net;
using System.Net.Mime;

namespace WebApi.Test.Reports;
public class GenerateExpensesReportTest : CashFlowClassFixture
{
    private const string METHOD = "api/Report";

    private readonly string _adminToken;
    private readonly string _teamMemberToken;
    private readonly DateTime _expenseDate;

    public GenerateExpensesReportTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _adminToken = webApplicationFactory.User_Admin.GetToken();
        _teamMemberToken = webApplicationFactory.User_Team_Member.GetToken();
        _expenseDate = webApplicationFactory.Expense_Admin.GetDate();

    }

    [Fact]

    public async Task Success_Excel()
    {
        var result = await DoGet(requestUri: $"{METHOD}/excel?month={_expenseDate:yyyy-MM}", token: _adminToken);

        result.StatusCode.Should().Be(HttpStatusCode.OK);

        result.Content.Headers.ContentType.Should().NotBeNull();
        result.Content.Headers.ContentType!.MediaType.Should().Be(MediaTypeNames.Application.Octet);
        
        var content = await result.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }

    [Fact]

    public async Task Error_Forbidden_User_Not_Allowed_Excel()
    {
        var result =  await DoGet(requestUri: $"{METHOD}/excel?month={_expenseDate:Y}", token: _teamMemberToken);

        result.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }

}
