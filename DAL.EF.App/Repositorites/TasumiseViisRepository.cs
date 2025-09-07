using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class TasumiseViisRepository : EFBaseRepository<TasumiseViis, ApplicationDbContext>, ITasumiseViisRepository
{
    public TasumiseViisRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<TasumiseViis>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.Osavotumaksud)
            .OrderBy(e => e.ViisNimetus)
            .ToListAsync();
    }

    public override async Task<TasumiseViis?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.Osavotumaksud)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TasumiseViis?> RemoveAsync(Guid id)
    {
        var tasumiseViis = await FindAsync(id);
        return tasumiseViis == null ? null : Remove(tasumiseViis);
    }
}