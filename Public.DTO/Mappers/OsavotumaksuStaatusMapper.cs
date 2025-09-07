using AutoMapper;
using DAL.Base;

namespace Public.DTO.Mappers;

public class OsavotumaksuStaatusMapper : BaseMapper<BLL.DTO.OsavotumaksuStaatus, Public.DTO.v1.OsavotumaksuStaatus>
{
    public OsavotumaksuStaatusMapper(IMapper mapper) : base(mapper)
    {

    }
}