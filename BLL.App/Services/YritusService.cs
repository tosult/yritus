using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class YritusService : BaseEntityService<BLL.DTO.Yritus, Domain.App.Yritus, IYritusRepository>, IYritusService
{
    protected IAppUOW Uow;

    public YritusService(IAppUOW uow, IMapper<BLL.DTO.Yritus, Domain.App.Yritus> mapper) :
        base(uow.YritusRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.Yritus>> AllAsync()
    {
        return (await Uow.YritusRepository.AllAsync()).Select(
            e => Mapper.Map(e)
        );
    }

    public async Task<DTO.Yritus?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.YritusRepository.FindAsync(id));
    }

    public async Task<DTO.Yritus?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.YritusRepository.RemoveAsync(id));
    }
}