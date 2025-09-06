using DAL.Contracts.Base;

namespace DAL.Contracts.App;

public interface IAppUOW : IBaseUOW
{
    IIsikRepository IsikRepository { get; }
    
    IIsikYrituselRepository IsikYrituselRepository { get; }
    
    IIsikYrituselRollRepository IsikYrituselRollRepository { get; }
    
    IJurIsikRepository JurIsikRepository { get; }
    
    IJurIsikLiikRepository JurIsikLiikRepository { get; }
    
    IOsavotumaksRepository OsavotumaksRepository { get; }
    
    IOsavotumaksuStaatusRepository OsavotumaksuStaatusRepository { get; }
    
    ITasumiseViisRepository TasumiseViisRepository { get; }
    
    IYritusRepository YritusRepository { get; }
}