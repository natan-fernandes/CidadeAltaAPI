using CidadeAlta.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Status = CidadeAlta.Domain.Models.Status;

namespace CidadeAlta.Data.Seeds;

public static class StatusSeed
{
    public static void RunSeed(ModelBuilder modelBuilder)
    {
        var values = Enum.GetValues(typeof(Domain.Enums.Status)).Cast<int>()
            .Select(x => new Status
            {
                Id = x,
                Name = EnumHelper.GetEnumDescription((Domain.Enums.Status)x)
            });

        modelBuilder.Entity<Status>().HasData(values);
    }
}