using CidadeAlta.Domain.Validators;
using FluentValidation.Results;

namespace CidadeAlta.Domain.Models;

public class User : Entity
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;

    public virtual ICollection<CriminalCode>? CreatedCriminalCodes { get; set; }
    public virtual ICollection<CriminalCode>? UpdatedCriminalCodes { get; set; }

    public ValidationResult ValidationResult => new UserValidator().Validate(this);
    public bool IsValid => ValidationResult.IsValid;
    public IEnumerable<string> Errors => ValidationResult.Errors.Select(x => x.ErrorMessage);
}