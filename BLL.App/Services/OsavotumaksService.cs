using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class OsavotumaksService : BaseEntityService<BLL.DTO.Osavotumaks, Domain.App.Osavotumaks, IOsavotumaksRepository>, IOsavotumaksService
{
    protected IAppUOW Uow;

    public OsavotumaksService(IAppUOW uow, IMapper<BLL.DTO.Osavotumaks, Domain.App.Osavotumaks> mapper) :
        base(uow.OsavotumaksRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.Osavotumaks>> AllAsync()
    {
        return (await Uow.OsavotumaksRepository.AllAsync()).Select(
            e => Mapper.Map(e)
        );
    }

    public async Task<DTO.Osavotumaks?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.OsavotumaksRepository.FindAsync(id));
    }

    public async Task<DTO.Osavotumaks?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.OsavotumaksRepository.RemoveAsync(id));
    }
}