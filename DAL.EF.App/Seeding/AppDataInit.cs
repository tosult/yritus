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
        // TODO: SeedAppDataRollid();
        // TODO: SeedAppDataVormid();
        // TODO: SeedAppDataViisid();
        context.SaveChanges();
    }
}