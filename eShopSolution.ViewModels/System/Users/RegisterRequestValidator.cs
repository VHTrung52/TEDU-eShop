﻿using FluentValidation;
using LazZiya.ExpressLocalization;
using System;

namespace eShopSolution.ViewModels.System.Users
{

    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        private readonly ISharedCultureLocalizer _localizer;
        public RegisterRequestValidator(ISharedCultureLocalizer localizer)
        {
            _localizer = localizer;
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(x => _localizer.GetLocalizedString("Test"));
            //.WithMessage("First name is required");
            //.MaximumLength(200).WithMessage("First name can not over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(200).WithMessage("Last name is at over 200 characters");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Password and ConfirmPassword is not match");
                }
            });
        }
    }
}