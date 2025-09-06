using AutoMapper;
using DAL.Base;

namespace BLL.App.Mappers;

public class JurIsikLiikMapper : BaseMapper<BLL.DTO.JurIsikLiik, Domain.App.JurIsikLiik>
{
    public JurIsikLiikMapper(IMapper mapper) : base(mapper)
    {
    }
}