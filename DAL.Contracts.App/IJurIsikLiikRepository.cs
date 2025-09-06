using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IJurIsikLiikRepository : IBaseRepository<JurIsikLiik>, IJurIsikLiikRepositoryCustom<JurIsikLiik>
{
    
}

public interface IJurIsikLiikRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> AllAsync();
    
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}