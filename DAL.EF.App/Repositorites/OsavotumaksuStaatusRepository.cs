using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class OsavotumaksuStaatusRepository : EFBaseRepository<OsavotumaksuStaatus, ApplicationDbContext>, IOsavotumaksuStaatusRepository
{
    public OsavotumaksuStaatusRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<OsavotumaksuStaatus>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.Osavotumaksud)
            .OrderBy(e => e.Staatus)
            .ToListAsync();
    }

    public override async Task<OsavotumaksuStaatus?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.Osavotumaksud)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<OsavotumaksuStaatus?> RemoveAsync(Guid id)
    {
        var osavotumaksuStaatus = await FindAsync(id);
        return osavotumaksuStaatus == null ? null : Remove(osavotumaksuStaatus);
    }
}