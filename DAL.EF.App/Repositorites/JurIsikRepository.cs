using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class JurIsikRepository : EFBaseRepository<JurIsik, ApplicationDbContext>, IJurIsikRepository
{
    public JurIsikRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<JurIsik>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.IsikudYritusel)
            .OrderBy(e => e.Nimi)
            .ToListAsync();
    }

    public override async Task<JurIsik?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.IsikudYritusel)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<JurIsik?> RemoveAsync(Guid id)
    {
        var jurIsik = await FindAsync(id);
        return jurIsik == null ? null : Remove(jurIsik);
    }
}