using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class YritusMapper : BaseMapper<BLL.DTO.Yritus, Domain.App.Yritus>
{
    public YritusMapper(IMapper mapper) : base(mapper)
    {
    }
}