using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IIsikYrituselService : IBaseRepository<BLL.DTO.IsikYritusel>, IIsikYrituselRepositoryCustom<BLL.DTO.IsikYritusel>
{
    // TODO: Custom servie methods
}