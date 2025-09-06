using DAL.Contracts.Base;
using Domain.App;

namespace DAL.Contracts.App;

public interface IYritusRepository : IBaseRepository<Yritus>, IYritusRepositoryCustom<Yritus>
{
    
}

public interface IYritusRepositoryCustom<TEntity>
{
    Task<TEntity?> FindAsync(Guid id);
    
    Task<TEntity?> RemoveAsync(Guid id);
}