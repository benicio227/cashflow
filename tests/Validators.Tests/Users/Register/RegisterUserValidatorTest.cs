﻿using CashFlow3.Application.UseCases.Users.Register;
using CashFlow3.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Users.Register;
public class RegisterUserValidatorTest
{
    [Fact]
    public void Success()
    {
        var validator = new RegisterUserValidator();
        var request = RequestUserJsonBuilder.Builder();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]

    public void Error_Name_Empty(string name)
    {
        var validator = new RegisterUserValidator();
        var request = RequestUserJsonBuilder.Builder();
        request.Name = name;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]

    public void Error_Email_Empty(string email)
    {
        var validator = new RegisterUserValidator();
        var request = RequestUserJsonBuilder.Builder();
        request.Email = email;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_CANNOT_BE_EMPTY));
    }

    [Fact]
    public void Error_Password_Empty()
    {
        var validator = new RegisterUserValidator();
        var request = RequestUserJsonBuilder.Builder();
        request.Password = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.INVALID_PASSWORD));
    }
}
