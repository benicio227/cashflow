using CashFlow3.Domain.Entities;
using CashFlow3.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebApi.Test.InlineData;
using WebApi.Test.Resources;

namespace WebApi.Test.Expenses.Register;
public class RegisterExpenseTest : CashFlowClassFixture
{
    private const string METHOD = "api/Expenses";

    private readonly string _token;

    public RegisterExpenseTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        var user = new User { Name = "Test User", Email = "test@test.com" };
        var userIdentityManager = new UserIdentityManager(user, "password123", "example_token");

        _token = userIdentityManager.GetToken();


        // = webApplicationFactory.GetToken();
    }

    [Fact]

    public async Task Success()
    {
        var request = RequestExpenseJsonBuilder.Build();


        var result = await DoPost(requestUri: METHOD, request: request, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.Created);

        var body = await result.Content.ReadAsStringAsync();

        var response = JsonDocument.Parse(body);

        response.RootElement.GetProperty("title").GetString().Should().Be(request.Title);
    }

    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]

    public async Task Error_Title_Empty(string culture)
    {
        var request = RequestExpenseJsonBuilder.Build();
        request.Title = string.Empty;
        


        var result = await DoPost(requestUri: METHOD, request: request, token: _token, culture: culture);

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var body = await result.Content.ReadAsStringAsync();

        var response = JsonDocument.Parse(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("TITLE_REQUIRED", new CultureInfo(culture));

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage));
    }
}
