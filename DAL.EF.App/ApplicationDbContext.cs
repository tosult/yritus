using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App;

public class ApplicationDbContext : DbContext
{
    public DbSet<Isik> Isikud { get; set; } = default!;
    
    public DbSet<IsikYritusel> IsikudYritusel { get; set; } = default!;
    
    public DbSet<IsikYrituselRoll> IsikYrituselRollid { get; set; } = default!;
    
    public DbSet<JurIsik> JurIsikud { get; set; } = default!;
    
    public DbSet<JurIsikLiik> JurIsikLiigid { get; set; } = default!;
    
    public DbSet<Osavotumaks> Osavotumaksud { get; set; } = default!;
    
    public DbSet<OsavotumaksuStaatus> OsavotumaksuStaatused {  get; set; } = default!;
    
    public DbSet<TasumiseViis> TasumiseViisid { get; set; } = default!;
    
    public DbSet<Yritus> Yritused { get; set; } = default!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }
}