using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class OsavotumaksuStaatusMapper : BaseMapper<BLL.DTO.OsavotumaksuStaatus, Domain.App.OsavotumaksuStaatus>
{
    public OsavotumaksuStaatusMapper(IMapper mapper) : base(mapper)
    {
    }
}