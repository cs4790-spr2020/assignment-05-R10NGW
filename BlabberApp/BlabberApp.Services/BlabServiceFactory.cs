using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.DataStore.Plugins;

namespace BlabberApp.Services
{
    /// <summary>
    /// Disclaimer!  I have no clue what Services are/What they do.
    /// These files should pretty much be a copy paste, because I'm afraid of breaking things.
    /// 
    /// This class seems to provide a way to get Blab overhead.
    /// It seems odd that these methods aren't static.
    /// </summary>
    public class BlabServiceFactory
    {
        /// <summary>
        /// Makes the Blabber adapter
        /// </summary>
        /// <param name="plugin">Accepts a plugin, but doesn't require one.</param>
        /// <returns></returns>
        public BlabAdapter CreateBlabAdapter(IBlabPlugin plugin = null)
        {
            if (plugin == null)
            {
                plugin = CreateBlabPlugin();
            }
            return new BlabAdapter(plugin);
        }
        /// <summary>
        /// Creates a Blab Plugin?
        /// </summary>
        /// <param name="type">The type of memory?  MYSQL connects to the server</param>
        /// <returns></returns>
        public IBlabPlugin CreateBlabPlugin(string type = "")
        {
            if (type.ToUpper().Equals("MYSQL"))
            {
                return new MySqlBlab();
            }
            return new InMemory();
        }
        /// <summary>
        /// Creates a Blab Service?
        /// </summary>
        /// <param name="adapter">BlabAdapter object</param>
        /// <returns></returns>
        public BlabService CreateBlabService(BlabAdapter adapter = null)
        {
            if (adapter == null)
            {
                adapter = CreateBlabAdapter();
            }
            return new BlabService(adapter);
        }
    }
}
