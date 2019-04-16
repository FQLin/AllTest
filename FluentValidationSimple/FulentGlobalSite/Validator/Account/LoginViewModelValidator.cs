using FluentValidation;
using FulentGlobalSite.Models.Account;

namespace FulentGlobalSite.Validator.Account
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(l => l.Password).NotEmpty().WithMessage("非空").Length(5, 100);
            RuleFor(l => l.UserName).NotEmpty().Length(5, 100).WithMessage("'{PropertyName}' 必须是 {MaxLength} 个字符，您已经输入了 {TotalLength} 字符。");
            RuleFor(l => l.Code).NotEmpty().MaximumLength(4);
        }
    }
}