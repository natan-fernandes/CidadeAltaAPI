using System.ComponentModel.DataAnnotations.Schema;
using CidadeAlta.Domain.Validators;

namespace CidadeAlta.Domain.Models;

public class User : Entity
{
    public User()
    {
        Validator = new UserValidator();
    }

    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;

    public virtual ICollection<CriminalCode>? CreatedCriminalCodes { get; set; }
    public virtual ICollection<CriminalCode>? UpdatedCriminalCodes { get; set; }

    [NotMapped]
    public UserValidator Validator { get; }
}