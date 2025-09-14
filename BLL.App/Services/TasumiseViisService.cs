using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class TasumiseViisService : BaseEntityService<BLL.DTO.TasumiseViis, Domain.App.TasumiseViis, ITasumiseViisRepository>, ITasumiseViisService
{
    protected IAppUOW Uow;

    public TasumiseViisService(IAppUOW uow, IMapper<BLL.DTO.TasumiseViis, Domain.App.TasumiseViis> mapper) :
        base(uow.TasumiseViisRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.TasumiseViis>> AllAsync()
    {
        return (await Uow.TasumiseViisRepository.AllAsync()).Select(
            e => Mapper.Map(e)!
        );
    }

    public async Task<DTO.TasumiseViis?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.TasumiseViisRepository.FindAsync(id));
    }

    public async Task<DTO.TasumiseViis?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.TasumiseViisRepository.RemoveAsync(id));
    }
}