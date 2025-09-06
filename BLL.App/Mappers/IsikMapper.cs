using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class IsikMapper : BaseMapper<BLL.DTO.Isik, Domain.App.Isik>
{
    public IsikMapper(IMapper mapper) : base(mapper)
    {
    }
}