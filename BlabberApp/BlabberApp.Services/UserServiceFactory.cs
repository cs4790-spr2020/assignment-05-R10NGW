using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.DataStore.Plugins;

namespace BlabberApp.Services
{
    /// <summary>
    /// Disclaimer!  I have no clue what Services are/What they do.
    /// These files should pretty much be a copy paste, because I'm afraid of breaking things.
    /// 
    /// Looks like a class to get/make Adapter/Plugin objects.  Don't know why the methods aren't static.
    /// </summary>
    public class UserServiceFactory
    {
        /// <summary>
        /// Creates a User Adapter
        /// </summary>
        /// <param name="plugin">IUserPlugin object to use</param>
        /// <returns>UserAdapter object</returns>
        public UserAdapter CreateUserAdapter(IUserPlugin plugin = null)
        {
            if (plugin == null)
            {
                plugin = CreateUserPlugin();
            }

            return new UserAdapter(plugin);
        }
        /// <summary>
        /// Creates a User Plugin
        /// </summary>
        /// <param name="type">'MYSQL' put it in the DB</param>
        /// <returns>IUserPlugin Object</returns>
        public IUserPlugin CreateUserPlugin(string type = "")
        {
            if (type.ToUpper().Equals("MYSQL"))
            {
                return new MySqlUser();
            }

            return new InMemory();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public UserService CreateUserService(UserAdapter adapter = null)
        {
            if (adapter == null)
            {
                adapter = CreateUserAdapter();
            }

            return new UserService(adapter);
        }
    }
}
