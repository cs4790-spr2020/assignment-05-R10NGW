using System.Collections;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    /// <summary>
    /// Disclaimer!  I have no clue what Services are/What they do.
    /// These files should pretty much be a copy paste, because I'm afraid of breaking things.
    /// 
    /// Interface  for Blab service, seems like a wrapper for adapter and plugin?
    /// </summary>
    public interface IBlabService
    {
       void AddBlab(string message, string email);
       void AddBlab(Blab blab);
       IEnumerable FindUserBlabs(string email);
       IEnumerable GetAll(); 
    }
}