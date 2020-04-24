using System.Collections;

namespace BlabberApp.DataStore.Interfaces
{
    /// <summary>
    /// Not sure what this does, but Don had it.
    /// </summary>
    public interface IBlabPlugin : IPlugin
    {
        IEnumerable ReadByUserId(string Id);
    }
}