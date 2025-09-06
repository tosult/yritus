using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IOsavotumaksuStaatusRepository : IBaseRepository<OsavotumaksuStaatus>, IOsavotumaksuStaatusRepositoryCustom<OsavotumaksuStaatus>
{
    
}

public interface IOsavotumaksuStaatusRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> AllAsync();
    
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}