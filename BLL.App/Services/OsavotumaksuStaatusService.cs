using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class OsavotumaksuStaatusService : BaseEntityService<BLL.DTO.OsavotumaksuStaatus, Domain.App.OsavotumaksuStaatus, IOsavotumaksuStaatusRepository>, IOsavotumaksuStaatusService
{
    protected IAppUOW Uow;

    public OsavotumaksuStaatusService(IAppUOW uow, IMapper<BLL.DTO.OsavotumaksuStaatus, Domain.App.OsavotumaksuStaatus> mapper) :
        base(uow.OsavotumaksuStaatusRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.OsavotumaksuStaatus>> AllAsync()
    {
        return (await Uow.OsavotumaksuStaatusRepository.AllAsync()).Select(
            e => Mapper.Map(e)
        );
    }

    public async Task<DTO.OsavotumaksuStaatus?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.OsavotumaksuStaatusRepository.FindAsync(id));
    }

    public async Task<DTO.OsavotumaksuStaatus?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.OsavotumaksuStaatusRepository.RemoveAsync(id));
    }
}