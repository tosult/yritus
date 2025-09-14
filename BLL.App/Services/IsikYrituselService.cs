using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class IsikYrituselService : BaseEntityService<BLL.DTO.IsikYritusel, Domain.App.IsikYritusel, IIsikYrituselRepository>, IIsikYrituselService
{
    protected IAppUOW Uow;

    public IsikYrituselService(IAppUOW uow, IMapper<BLL.DTO.IsikYritusel, Domain.App.IsikYritusel> mapper) :
        base(uow.IsikYrituselRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.IsikYritusel>> AllAsync()
    {
        return (await Uow.IsikYrituselRepository.AllAsync()).Select(
            e => Mapper.Map(e)!
        );
    }

    public async Task<DTO.IsikYritusel?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.IsikYrituselRepository.FindAsync(id));
    }

    public async Task<DTO.IsikYritusel?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.IsikYrituselRepository.RemoveAsync(id));
    }
}