using FluentValidation;
using NLWLibrary.Communication.Requests;

namespace NLWLibary.Api.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatorio");
        RuleFor(request => request.Email).NotEmpty().WithMessage("O email não é valido");
        When(request => string.IsNullOrEmpty(request.Password) == false, () =>
        {
            RuleFor(request => request.Password.Length).NotEmpty().GreaterThan(6).WithMessage("A senha deve ter mais que 6 caracteres");
        });
    }
}
