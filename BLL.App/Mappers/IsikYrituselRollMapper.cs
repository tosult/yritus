using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class IsikYrituselRollMapper : BaseMapper<BLL.DTO.IsikYrituselRoll, Domain.App.IsikYrituselRoll>
{
    public IsikYrituselRollMapper(IMapper mapper) : base(mapper)
    {
    }
}