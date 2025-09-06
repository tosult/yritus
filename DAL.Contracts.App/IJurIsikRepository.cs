using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IJurIsikRepository : IBaseRepository<JurIsik>, IJurIsikRepositoryCustom<JurIsik>
{
    
}

public interface IJurIsikRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> AllAsync();
    
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}