using CidadeAlta.Domain.Validators;
using FluentValidation.Results;

namespace CidadeAlta.Domain.Models;

public class CriminalCode : Entity
{
    public CriminalCode()
    {
        CreateDate = DateTime.UtcNow;
        UpdateDate = DateTime.UtcNow;
    }
    
    public Guid CreateUserId { get; set; }
    public virtual User CreateUser { get; set; } = null!;

    public Guid UpdateUserId { get; set; }
    public virtual User UpdateUser { get; set; } = null!;

    public int StatusId { get; set; }
    public virtual Status Status { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal? Penalty { get; set; }
    public int? PrisonTime { get; set; }
    
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }

    public ValidationResult ValidationResult => new CriminalCodeValidator().Validate(this);
    public bool IsValid => ValidationResult.IsValid;
    public IEnumerable<string> Errors => ValidationResult.Errors.Select(x => x.ErrorMessage);
}