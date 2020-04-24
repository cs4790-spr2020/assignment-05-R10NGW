using System;
using System.Collections;
using BlabberApp.DataStore.Adapters;
using BlabberApp.Domain.Entities;

namespace BlabberApp.Services
{
    /// <summary>
    /// Disclaimer!  I have no clue what Services are/What they do.
    /// These files should pretty much be a copy paste, because I'm afraid of breaking things.
    /// 
    /// This class looks like it just hides the adapter?
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Pretends to do all the work?  Hides plugin?
        /// </summary>
        private readonly UserAdapter adapter;
        /// <summary>
        /// Initialize the adapter
        /// </summary>
        /// <param name="adapter"></param>
        public UserService(UserAdapter adapter)
        {
            this.adapter = adapter;
        }
        /// <summary>
        /// Calls getall on the adapter
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAll()
        {
            return adapter.GetAll();
        }
        /// <summary>
        /// Calls add on the adapter object
        /// </summary>
        /// <param name="email">User email</param>
        public void AddNewUser(string email)
        {
            try
            {
                adapter.Add(CreateUser(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// Creates a user object from an email
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User object</returns>
        public User CreateUser(string email)
        {
            return new User(email);
        }
        /// <summary>
        /// Calls GetByEmail on the Adapter
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>User associated with given email</returns>
        public User FindUser(string email)
        {
            return adapter.GetByEmail(email);
        }
    }
}
