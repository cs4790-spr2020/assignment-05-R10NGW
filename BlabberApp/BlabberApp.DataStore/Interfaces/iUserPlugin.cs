using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Interfaces
{
    /// <summary>
    /// Not sure what this is, but Don had it.
    /// </summary>
    public interface IUserPlugin : IPlugin
    {
        IEntity ReadByUserEmail(string email);
    }
}