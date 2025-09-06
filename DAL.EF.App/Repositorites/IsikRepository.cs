using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class IsikRepository : EFBaseRepository<Isik, ApplicationDbContext>, IIsikRepository
{
    public IsikRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<Isik>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.IsikudYritusel)
            .OrderBy(e => e.Perenimi)
            .ToListAsync();
    }

    public override async Task<Isik?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.IsikudYritusel)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Isik?> RemoveAsync(Guid id)
    {
        var isik = await FindAsync(id);
        return isik == null ? null : Remove(isik);
    }
}