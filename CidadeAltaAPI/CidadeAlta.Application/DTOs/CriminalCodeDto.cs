// ReSharper disable UnusedMember.Global
// ReSharper disable UnassignedGetOnlyAutoProperty
namespace CidadeAlta.Application.DTOs;

public class CriminalCodeDto : EntityDto
{
    public CriminalCodeDto()
    {
        CreateDate = DateTime.UtcNow;
        UpdateDate = DateTime.UtcNow;
    }

    public Guid CreateUserId { get; }
    public Guid UpdateUserId { get; }
    public int StatusId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal? Penalty { get; set; }
    public int? PrisonTime { get; set; }
    public DateTime CreateDate { get; }
    public DateTime UpdateDate { get; }
}