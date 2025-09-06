using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IIsikRepository : IBaseRepository<Isik>, IIsikRepositoryCustom<Isik>
{
    
}

public interface IIsikRepositoryCustom<TEntity>
{
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}