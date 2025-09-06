using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class IsikYrituselRepository : EFBaseRepository<IsikYritusel, ApplicationDbContext>, IIsikYrituselRepository
{
    public IsikYrituselRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<IsikYritusel>> AllAsync()
    {
        return await RepositoryDbSet
            .OrderBy(e => e.YritusId)
            .ToListAsync();
    }

    public override async Task<IsikYritusel?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IsikYritusel?> RemoveAsync(Guid id)
    {
        var isikYritusel = await FindAsync(id);
        return isikYritusel == null ? null : Remove(isikYritusel);
    }
}