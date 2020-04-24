using System.Collections;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    /// <summary>
    /// Disclaimer!  I have no clue what Services are/What they do.
    /// These files should pretty much be a copy paste, because I'm afraid of breaking things.
    /// 
    /// Interface for UserService, seems like a wrapper for adapter/plugin
    /// </summary>
    public interface IUserService
    {
       IEnumerable GetAll(); 
       void AddNewUser(string email);
       User CreateUser(string email);
       User FindUser(string email);
    }
}