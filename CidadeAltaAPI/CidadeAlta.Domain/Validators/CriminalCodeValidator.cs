using CidadeAlta.Domain.Models;
using FluentValidation;

namespace CidadeAlta.Domain.Validators;

public class CriminalCodeValidator : AbstractValidator<CriminalCode>
{
    public CriminalCodeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O código penal deve ter um nome.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("O código penal deve ter uma descrição");

        RuleFor(x => x.StatusId)
            .Must(x => Enum.GetValues(typeof(Enums.Status)).Cast<int>().Contains(x))
            .WithMessage("O status definido é inválido");
    }
}