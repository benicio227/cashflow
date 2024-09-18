﻿using CashFlow3.Communication.Requests;
using CashFlow3.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebApi.Test.InlineData;

namespace WebApi.Test.Users.ChangePassword;
public class ChangePasswordTest : CashFlowClassFixture
{
    private const string METHOD = "api/User/Change-password";

    private readonly string _token;
    private readonly string _password;
    private readonly string _email;

    public ChangePasswordTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.User_Team_Member.GetToken();
        _password = webApplicationFactory.User_Team_Member.GetPassword();
        _email = webApplicationFactory.User_Team_Member.GetEmail();
    }

    [Fact]

    public async Task Success()
    {
        var request = RequestChangePasswordJsonBuilder.Build();
        request.Password = _password;

        var response = await DoPut(METHOD, request, _token);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var logginRequest = new RequestLoginJson
        {
            Email = _email,
            Password = _password
        };


        response = await DoPost("api/Login", logginRequest);
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        logginRequest.Password = request.NewPassword;

        response = await DoPost("api/Login", logginRequest);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }


    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]

    public async Task Error_Different_Current_Password(string culture)
    {
        var request = RequestChangePasswordJsonBuilder.Build();
       
        var response = await DoPut(METHOD, request, token: _token, culture: culture);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var responseBody = await response.Content.ReadAsStringAsync();

        var responseData = JsonDocument.Parse(responseBody);

        var errors = responseData.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("PASSWORD_DIFFERENT_CURRENT_PASSWORD", new CultureInfo(culture));

        errors.Should().HaveCount(1).And.Contain(C => C.GetString()!.Equals(expectedMessage));
    }
}
