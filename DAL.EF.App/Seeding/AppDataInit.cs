using System.Reflection.Metadata.Ecma335;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Seeding;

public static class AppDataInit
{
    public static void MigrateDataBase(ApplicationDbContext context)
    {
        context.Database.Migrate();
    }

    public static void DropDataBase(ApplicationDbContext context)
    {
        context.Database.EnsureDeleted();
    }

    public static void SeedAppData(ApplicationDbContext context)
    {
        SeedAppDataRollid(context);
        SeedAppDataVormid(context);
        SeedAppDataViisid(context);
        context.SaveChanges();
    }

    public static void SeedAppDataRollid(ApplicationDbContext context)
    {
        if (context.IsikYrituselRollid.Any()) return;

        context.IsikYrituselRollid.Add(new IsikYrituselRoll()
        {
            RollNimetus = "Osaleja"
        });
        context.IsikYrituselRollid.Add(new IsikYrituselRoll()
        {
            RollNimetus = "Korraldaja"
        });
    }

    public static void SeedAppDataVormid(ApplicationDbContext context)
    {
        if (context.JurIsikLiigid.Any()) return;

        context.JurIsikLiigid.Add(new JurIsikLiik()
        {
            LiikNimetus = "Füüsilisest isikust ettevõtja"
        });
        context.JurIsikLiigid.Add(new JurIsikLiik()
        {
            LiikNimetus = "Osaühing"
        });
        context.JurIsikLiigid.Add(new JurIsikLiik()
        {
            LiikNimetus = "Aktsiaselts"
        });
        context.JurIsikLiigid.Add(new JurIsikLiik()
        {
            LiikNimetus = "Täisühing"
        });
        context.JurIsikLiigid.Add(new JurIsikLiik()
        {
            LiikNimetus = "Usaldusühing"
        });
        context.JurIsikLiigid.Add(new JurIsikLiik()
        {
            LiikNimetus = "Tulundusühistu"
        });
    }
    
    public static void SeedAppDataViisid(ApplicationDbContext context)
    {
        if (context.TasumiseViisid.Any()) return;

        context.TasumiseViisid.Add(new TasumiseViis()
        {
            ViisNimetus = "Pangaülekanne"
        });
        context.TasumiseViisid.Add(new TasumiseViis()
        { 
            ViisNimetus = "Sularaha"
        });
    }
}