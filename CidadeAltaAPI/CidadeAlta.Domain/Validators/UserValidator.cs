using CidadeAlta.Domain.Models;
using FluentValidation;

namespace CidadeAlta.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("O usuário precisa ter um nome.")
            .MinimumLength(3).WithMessage("O nome do usuário precisa ter pelo menos 3 caracteres.")
            .MaximumLength(15).WithMessage("O nome do usuário precisa ter menos de 16 caracteres.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("O usuário precisa ter uma senha.")
            .MinimumLength(5).WithMessage("A senha do usuário precisa ter pelo menos 5 caracteres");
    }
}
