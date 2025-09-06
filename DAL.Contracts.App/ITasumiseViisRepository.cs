using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface ITasumiseViisRepository : IBaseRepository<TasumiseViis>, ITasumiseViisRepositoryCustom<TasumiseViis>
{
    
}

public interface ITasumiseViisRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> AllAsync();
    
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}