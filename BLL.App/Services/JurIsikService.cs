using BLL.Base;
using BLL.Contracts.App;
using Contracts.Base;
using DAL.Contracts.App;

namespace BLL.App.Services;

public class JurIsikService : BaseEntityService<BLL.DTO.JurIsik, Domain.App.JurIsik, IJurIsikRepository>, IJurIsikService
{
    protected IAppUOW Uow;

    public JurIsikService(IAppUOW uow, IMapper<BLL.DTO.JurIsik, Domain.App.JurIsik> mapper) :
        base(uow.JurIsikRepository, mapper)
    {
        Uow = uow;
    }
    
    public async Task<IEnumerable<DTO.JurIsik>> AllAsync()
    {
        return (await Uow.JurIsikRepository.AllAsync()).Select(
            e => Mapper.Map(e)!
        );
    }

    public async Task<DTO.JurIsik?> FindAsync(Guid id)
    {
        return Mapper.Map(await Uow.JurIsikRepository.FindAsync(id));
    }

    public async Task<DTO.JurIsik?> RemoveAsync(Guid id)
    {
        return Mapper.Map(await Uow.JurIsikRepository.RemoveAsync(id));
    }
}