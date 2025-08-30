﻿

using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validation;
public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        //
        RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address format");

        //Password
        RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required");
    }
}

