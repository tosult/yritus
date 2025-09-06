using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IYritusService : IBaseRepository<BLL.DTO.Yritus>, IYritusRepositoryCustom<BLL.DTO.Yritus>
{
    // TODO: Custom servie methods
}