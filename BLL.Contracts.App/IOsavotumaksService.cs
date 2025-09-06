using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IOsavotumaksService : IBaseRepository<BLL.DTO.Osavotumaks>, IOsavotumaksRepositoryCustom<BLL.DTO.Osavotumaks>
{
    // TODO: Custom servie methods
}