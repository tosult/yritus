using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class IsikYrituselRollRepository : EFBaseRepository<IsikYrituselRoll, ApplicationDbContext>, IIsikYrituselRollRepository
{
    public IsikYrituselRollRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<IsikYrituselRoll>> AllAsync()
    {
        return await RepositoryDbSet
            .ToListAsync();
    }

    public override async Task<IsikYrituselRoll?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IsikYrituselRoll?> RemoveAsync(Guid id)
    {
        var isikYrituselRoll = await FindAsync(id);
        return isikYrituselRoll == null ? null : Remove(isikYrituselRoll);
    }
}