using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IIsikYrituselRepository : IBaseRepository<IsikYritusel>, IIsikYrituselRepositoryCustom<IsikYritusel>
{
    
}

public interface IIsikYrituselRepositoryCustom<TEntity>
{
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}