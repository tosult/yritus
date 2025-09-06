using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IIsikYrituselRollRepository : IBaseRepository<IsikYrituselRoll>, IIsikYrituselRollRepositoryCustom<IsikYrituselRoll>
{
    
}

public interface IIsikYrituselRollRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> AllAsync();
    
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}