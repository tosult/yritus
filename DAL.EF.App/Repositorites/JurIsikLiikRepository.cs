using DAL.Contracts.App;
using DAL.EF.Base;
using Domain.App;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.App.Repositorites;

public class JurIsikLiikRepository : EFBaseRepository<JurIsikLiik, ApplicationDbContext>, IJurIsikLiikRepository
{
    public JurIsikLiikRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public override async Task<IEnumerable<JurIsikLiik>> AllAsync()
    {
        return await RepositoryDbSet
            .Include(e => e.JurIsikud)
            .OrderBy(e => e.Liik)
            .ToListAsync();
    }

    public override async Task<JurIsikLiik?> FindAsync(Guid id)
    {
        return await RepositoryDbSet
            .Include(e => e.JurIsikud)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<JurIsikLiik?> RemoveAsync(Guid id)
    {
        var jurIsikLiik = await FindAsync(id);
        return jurIsikLiik == null ? null : Remove(jurIsikLiik);
    }
}