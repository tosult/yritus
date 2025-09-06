using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IJurIsikService : IBaseRepository<BLL.DTO.JurIsik>, IJurIsikRepositoryCustom<BLL.DTO.JurIsik>
{
    // TODO: Custom servie methods
}