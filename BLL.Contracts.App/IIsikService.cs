using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IIsikService : IBaseRepository<BLL.DTO.Isik>, IIsikRepositoryCustom<BLL.DTO.Isik>
{
    // TODO: Custom servie methods
}