using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class IsikYrituselMapper : BaseMapper<BLL.DTO.IsikYritusel, Domain.App.IsikYritusel>
{
    public IsikYrituselMapper(IMapper mapper) : base(mapper)
    {
    }
}