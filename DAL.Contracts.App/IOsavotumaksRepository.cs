using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IOsavotumaksRepository : IBaseRepository<Osavotumaks>, IOsavotumaksRepositoryCustom<Osavotumaks>
{
    
}

public interface IOsavotumaksRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> AllAsync();
    
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}