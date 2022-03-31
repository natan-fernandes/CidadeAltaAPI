using System.ComponentModel.DataAnnotations.Schema;
using CidadeAlta.Domain.Validators;

namespace CidadeAlta.Domain.Models;

public class CriminalCode : Entity
{
    public CriminalCode()
    {
        CreateDate = DateTime.UtcNow;
        UpdateDate = DateTime.UtcNow;
        Validator = new CriminalCodeValidator();
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

    [NotMapped] 
    public CriminalCodeValidator Validator { get; set; }
}
