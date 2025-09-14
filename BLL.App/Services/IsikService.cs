using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class IsikService : BaseEntityService<BLL.DTO.Isik, Domain.App.Isik, IIsikRepository>, IIsikService
{
    protected IAppUOW Uow;

    public IsikService(IAppUOW uow, IMapper<BLL.DTO.Isik, Domain.App.Isik> mapper) :
        base(uow.IsikRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.Isik>> AllAsync()
    {
        return (await Uow.IsikRepository.AllAsync()).Select(
            e => Mapper.Map(e)!
        );
    }

    public async Task<DTO.Isik?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.IsikRepository.FindAsync(id));
    }

    public async Task<DTO.Isik?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.IsikRepository.RemoveAsync(id));
    }
}