using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class JurIsikLiikService : BaseEntityService<BLL.DTO.JurIsikLiik, Domain.App.JurIsikLiik, IJurIsikLiikRepository>, IJurIsikLiikService
{
    protected IAppUOW Uow;

    public JurIsikLiikService(IAppUOW uow, IMapper<BLL.DTO.JurIsikLiik, Domain.App.JurIsikLiik> mapper) :
        base(uow.JurIsikLiikRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.JurIsikLiik>> AllAsync()
    {
        return (await Uow.JurIsikLiikRepository.AllAsync()).Select(
            e => Mapper.Map(e)!
        );
    }

    public async Task<DTO.JurIsikLiik?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.JurIsikLiikRepository.FindAsync(id));
    }

    public async Task<DTO.JurIsikLiik?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.JurIsikLiikRepository.RemoveAsync(id));
    }
}