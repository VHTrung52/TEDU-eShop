using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Phải nhập tên người dùng");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Phải nhập mật khẩu")
                .MinimumLength(6).WithMessage("Mật khẩu có ít nhất 6 kí tự");
        }
    }
}