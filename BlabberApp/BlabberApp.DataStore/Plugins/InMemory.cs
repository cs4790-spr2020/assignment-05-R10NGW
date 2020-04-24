using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;
using BlabberApp.Domain.Interfaces;

namespace BlabberApp.DataStore.Plugins
{
    /// <summary>
    /// Reworked InMemory storage to match Don's
    /// </summary>
    public class InMemory : IBlabPlugin, IUserPlugin
    {
        /// <summary>
        /// List of Objects (Users or Blabs)
        /// </summary>
        private ArrayList buffer;

        /// <summary>
        /// Constructor for InMemory Storage (Not persistant)
        /// </summary>
        public InMemory()
        {
            buffer = new ArrayList();
        }

        /// <summary>
        /// Creates the object in memory
        /// </summary>
        /// <param name="obj">IEntity object</param>
        public void Create(IEntity obj)
        {
            buffer.Add(obj);
        }

        /// <summary>
        /// Returns entire InMemory object
        /// </summary>
        /// <returns>IEnumerable of IEntity Objects</returns>
        public IEnumerable ReadAll()
        {
            return buffer;
        }

        /// <summary>
        /// Gets object by GUID
        /// </summary>
        /// <param name="Id">GUID of object</param>
        /// <returns>Object associated with given GUID</returns>
        public IEntity ReadById(Guid Id)
        {
            foreach(IEntity obj in buffer)
            {
                if (Id.Equals(obj.Id)) return obj;
            }
            return null;
        }

        /// <summary>
        /// Gets object by User email.
        /// 
        /// I think this only works for User objects
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>User associated with Email</returns>
        public IEntity ReadByUserEmail(string email)
        {
            foreach(User user in buffer)
            {
                if (user.Email.Equals(email))
                {
                    return user;
                }
            }
            return null;
        }

        /// <summary>
        /// Update Object
        /// </summary>
        /// <param name="obj">Object to update</param>
        public void Update(IEntity obj)
        {
            Delete(obj);
            Create(obj);
        }

        /// <summary>
        /// Deletes object from memory
        /// </summary>
        /// <param name="obj">Object to delete</param>
        public void Delete(IEntity obj)
        {
            buffer.Remove(obj);
        }

        /// <summary>
        /// Not used, but required per the IBlabPlugin
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable ReadByUserId(string Id)
        {
            return null;
        }
    }
}
