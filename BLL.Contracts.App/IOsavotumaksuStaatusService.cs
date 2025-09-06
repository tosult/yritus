using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IOsavotumaksuStaatusService : IBaseRepository<BLL.DTO.OsavotumaksuStaatus>, IOsavotumaksuStaatusRepositoryCustom<BLL.DTO.OsavotumaksuStaatus>
{
    // TODO: Custom servie methods
}