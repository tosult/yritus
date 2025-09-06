using DAL.Contracts.App;
using DAL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IJurIsikLiikService : IBaseRepository<BLL.DTO.JurIsikLiik>, IJurIsikLiikRepositoryCustom<BLL.DTO.JurIsikLiik>
{
    // TODO: Custom servie methods
}