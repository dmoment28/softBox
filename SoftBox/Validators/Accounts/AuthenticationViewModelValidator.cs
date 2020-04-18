using FluentValidation;
using SoftBox.WEB.ViewModels.Accounts;

namespace SoftBox.WEB.Validators.Accounts
{
    public class AuthenticationViewModelValidator : AbstractValidator<AuthenticationViewModel>
    {
        public AuthenticationViewModelValidator()
        {
            RuleFor(x => x.Login).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Invalid Login");
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(3).MaximumLength(500).WithMessage("Invalid Password");
        }
    }
}
