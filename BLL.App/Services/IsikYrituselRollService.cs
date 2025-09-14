using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class IsikYrituselRollService : BaseEntityService<BLL.DTO.IsikYrituselRoll, Domain.App.IsikYrituselRoll, IIsikYrituselRollRepository>, IIsikYrituselRollService
{
    protected IAppUOW Uow;

    public IsikYrituselRollService(IAppUOW uow, IMapper<BLL.DTO.IsikYrituselRoll, Domain.App.IsikYrituselRoll> mapper) :
        base(uow.IsikYrituselRollRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.IsikYrituselRoll>> AllAsync()
    {
        return (await Uow.IsikYrituselRollRepository.AllAsync()).Select(
            e => Mapper.Map(e)!
        );
    }

    public async Task<DTO.IsikYrituselRoll?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.IsikYrituselRollRepository.FindAsync(id));
    }

    public async Task<DTO.IsikYrituselRoll?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.IsikYrituselRollRepository.RemoveAsync(id));
    }
}