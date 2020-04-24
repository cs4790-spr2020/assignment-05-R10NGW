using System;
using System.Collections;
using BlabberApp.DataStore.Interfaces;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Adapters
{
    public class BlabAdapter
    {
        //Plugin for the adapter.  The plugin is what does the work.
       private IBlabPlugin Plugin;

        /// <summary>
        /// Constructor for the BlabAdapter
        /// </summary>
        /// <param name="plugin"></param>
       public BlabAdapter(IBlabPlugin plugin)
       {
           Plugin = plugin;
       }
        /// <summary>
        /// Creates a brand new blab!
        /// </summary>
        /// <param name="blab">New Blab</param>
       public void Add(Blab blab)
       {
           Plugin.Create(blab);
       }

        /// <summary>
        /// Deletes a blab
        /// </summary>
        /// <param name="blab">Blab to delete</param>
       public void Remove(Blab blab)
       {
           Plugin.Delete(blab);
       }

        /// <summary>
        /// Updates Blab
        /// </summary>
        /// <param name="blab">Blab to update</param>
       public void Update(Blab blab)
       {
           Plugin.Update(blab);
       }

        /// <summary>
        /// Gets all available Blabs
        /// </summary>
        /// <returns>IEnumerable of Blab objects</returns>
       public IEnumerable GetAll()
       {
           return Plugin.ReadAll();
       }

        /// <summary>
        /// Get a Blab by the GUID
        /// </summary>
        /// <param name="Id">GUID of the Blab you wish to get</param>
        /// <returns></returns>
       public Blab GetById(Guid Id)
       {
           return (Blab)Plugin.ReadById(Id);
       }
       public IEnumerable GetByUserId(string Id)
       {
           return Plugin.ReadByUserId(Id);
       }
    }
}