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
    /// This class just seems like a wrapper for The adapter which is wrapper for the plugin
    /// </summary>
    public class BlabService : IBlabService
    {
        /// <summary>
        /// Adapter, pretends to do all the work by hiding the plugin?
        /// </summary>
        private readonly BlabAdapter adapter;
        /// <summary>
        /// Add a blab with a user email and message
        /// </summary>
        /// <param name="message">Message for the blab</param>
        /// <param name="email">User email</param>
        public void AddBlab(string message, string email)
        {
            adapter.Add(CreateBlab(message, email));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blab"></param>
        public void AddBlab(Blab blab)
        {
            adapter.Add(blab);
        }
        /// <summary>
        /// Initializes the service with an adapter
        /// </summary>
        /// <param name="adapter"></param>
        public BlabService(BlabAdapter adapter)
        {
            this.adapter = adapter;
        }
        /// <summary>
        /// Gets all blabs, not sure the difference between this and the adapter/plugin?
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAll()
        {
            return adapter.GetAll();
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IEnumerable FindUserBlabs(string email)
        {
            return null;
        }
        /// <summary>
        /// Appears to make a new blab by specifiying a user and a message
        /// </summary>
        /// <param name="msg">Message for the people!</param>
        /// <param name="email">User email</param>
        /// <returns>The Blab made</returns>
        public Blab CreateBlab(string msg, string email)
        {
            User usr = new User(email);
            return new Blab(msg, usr);
        }
    }
}
