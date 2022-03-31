namespace CidadeAlta.Domain.Models;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<CriminalCode>? CriminalCodes { get; set; } 
}
