using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class UserAdapter
    {
        //Plugin does all the work
       private readonly IUserPlugin Plugin;

        /// <summary>
        /// Constructor for UserAdapter
        /// </summary>
        /// <param name="plugin"></param>
       public UserAdapter(IUserPlugin plugin)
       {
           Plugin = plugin;
       }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="user">User to create</param>
       public void Add(User user)
       {
           Plugin.Create(user);
       }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="user">User to delete</param>
       public void Remove(User user)
       {
           Plugin.Delete(user);
       }

        /// <summary>
        /// Updates User
        /// </summary>
        /// <param name="user">User to update</param>
       public void Update(User user)
       {
           Plugin.Update(user);
       }

        /// <summary>
        /// Get all available Users
        /// </summary>
        /// <returns>IEnumerable of User objects</returns>
       public IEnumerable GetAll()
       {
           return Plugin.ReadAll();
       }

        /// <summary>
        /// Gets a User by GUID
        /// </summary>
        /// <param name="Id">GUID of User</param>
        /// <returns>The user associated with the given GUID</returns>
       public User GetById(Guid Id)
       {
           return (User)Plugin.ReadById(Id);
       }

        /// <summary>
        /// Gets a user by their email (unique?)
        /// </summary>
        /// <param name="email">Email of User</param>
        /// <returns>User associated with the given email</returns>
       public User GetByEmail(string email)
       {
           return (User)Plugin.ReadByUserEmail(email);
       }
    }
}