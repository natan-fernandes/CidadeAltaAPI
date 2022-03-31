using Microsoft.EntityFrameworkCore;
namespace CidadeAlta.Data.Seeds;

public static class Seed
{
    public static void RunSeed(ModelBuilder modelBuilder)
    {
        StatusSeed.RunSeed(modelBuilder);
    }
}