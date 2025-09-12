using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class YritusRepository : EFBaseRepository<Yritus, ApplicationDbContext>, IYritusRepository
{
    public YritusRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<Yritus>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.IsikudYritusel)
            .ThenInclude(e => e.Isik)
            .Include(e => e.IsikudYritusel)
            .ThenInclude(e => e.JurIsik)
            .OrderBy(e => e.Algus)
            .ToListAsync();
    }

    public override async Task<Yritus?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.IsikudYritusel)
            .ThenInclude(e => e.Isik)
            .Include(e => e.IsikudYritusel)
            .ThenInclude(e => e.JurIsik)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<Yritus?> RemoveAsync(Guid id)
    {
        var yritus = await FindAsync(id);
        return yritus == null ? null : Remove(yritus);
    }
}