using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class JurIsikMapper : BaseMapper<BLL.DTO.JurIsik, Domain.App.JurIsik>
{
    public JurIsikMapper(IMapper mapper) : base(mapper)
    {
    }
}