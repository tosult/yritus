using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IIsikYrituselRollService : IBaseRepository<BLL.DTO.IsikYrituselRoll>, IIsikYrituselRollRepositoryCustom<BLL.DTO.IsikYrituselRoll>
{
    // TODO: Custom servie methods
}