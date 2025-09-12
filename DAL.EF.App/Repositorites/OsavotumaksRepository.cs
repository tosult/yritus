using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class OsavotumaksRepository : EFBaseRepository<Osavotumaks, ApplicationDbContext>, IOsavotumaksRepository
{
    public OsavotumaksRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<Osavotumaks>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.Isikud)
            .Include(e => e.JurIsikud)
            .Include(e => e.TasumiseViis)
            .Include(e => e.OsavotumaksuStaatus)
            .OrderBy(e => e.OsavotumaksuStaatusId)
            .ToListAsync();
    }

    public override async Task<Osavotumaks?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.Isikud)
            .Include(e => e.JurIsikud)
            .Include(e => e.TasumiseViis)
            .Include(e => e.OsavotumaksuStaatus)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Osavotumaks?> RemoveAsync(Guid id)
    {
        var osavotumaks = await FindAsync(id);
        return osavotumaks == null ? null : Remove(osavotumaks);
    }
}