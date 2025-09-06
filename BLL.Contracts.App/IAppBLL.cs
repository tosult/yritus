using BLL.Contracts.Base;

namespace BLL.Contracts.App;

public interface IAppBLL : IBaseBLL
{
    IIsikService IsikService { get; }
    
    IIsikYrituselService IsikYrituselService { get; }
    
    IIsikYrituselRollService IsikYrituselRollService { get; }
    
    IJurIsikService JurIsikService { get; }
    
    IJurIsikLiikService JurIsikLiikService { get; }
    
    IOsavotumaksService OsavotumaksService { get; }
    
    IOsavotumaksuStaatusService OsavotumaksuStaatusService { get; }
    
    ITasumiseViisService TasumiseViisService { get; }
    
    IYritusService YritusService { get; }
}