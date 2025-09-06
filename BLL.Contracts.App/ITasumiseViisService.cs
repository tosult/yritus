using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface ITasumiseViisService : IBaseRepository<BLL.DTO.TasumiseViis>, ITasumiseViisRepositoryCustom<BLL.DTO.TasumiseViis>
{
    // TODO: Custom servie methods
}