using CidadeAlta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CidadeAlta.Data.Configurations;

public class CriminalCodeConfiguration : IEntityTypeConfiguration<CriminalCode>
{
    public void Configure(EntityTypeBuilder<CriminalCode> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasOne(m => m.Status).WithMany(m => m.CriminalCodes).HasForeignKey(m => m.StatusId);
        builder.HasOne(m => m.CreateUser).WithMany(m => m.CreatedCriminalCodes).HasForeignKey(m => m.CreateUserId);
        builder.HasOne(m => m.UpdateUser).WithMany(m => m.UpdatedCriminalCodes).HasForeignKey(m => m.UpdateUserId);

        builder.Property(m => m.Name).IsRequired();
        builder.Property(m => m.Description).IsRequired();
        builder.Property(m => m.CreateDate).IsRequired();
        builder.Property(m => m.UpdateDate).IsRequired();

        builder.Property(m => m.Penalty).IsRequired(false);
        builder.Property(m => m.PrisonTime).IsRequired(false);

        builder.ToTable("CriminalCodes");
    }
}