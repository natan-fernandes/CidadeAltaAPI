using CidadeAlta.Data.Seeds;
using CidadeAlta.Domain.Models;
using Microsoft.EntityFrameworkCore;

// ReSharper disable UnusedMember.Global
namespace CidadeAlta.Data;

public sealed class CidadeAltaContext : DbContext
{
    public CidadeAltaContext(DbContextOptions<CidadeAltaContext> options) : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CidadeAltaContext).Assembly);
        Seed.RunSeed(modelBuilder);
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<CriminalCode> CriminalCodes { get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null!;
}