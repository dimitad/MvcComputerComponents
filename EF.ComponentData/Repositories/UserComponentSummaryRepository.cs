using EF.ComponentData.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace EF.ComponentData.Repositories
{
    /// <summary>
    /// Repository class for managing the main component configuration
    /// </summary>
    public class UserComponentSummaryRepository : BaseRepository<UserComponentSummary>
    {
        /// <summary>
        /// Find the component configuration for a user ordered by the component category position and component name.
        /// </summary>
        /// <param name="userId">The unique GUID identifier for the user</param>
        /// <returns>A collection of components that the user has selected</returns>
        public virtual IList<UserComponentSummary> FindComponentItemListByUser(string userId)
        {
            return DbContext.Set<UserComponentSummary>()
                .Where(s => s.UserId.ToString().Equals(userId))
                .OrderBy(x => x.ComponentItem.ComponentCategory.Position)
                .ThenBy(x => x.ComponentItem.Name).ToList();
        }

        /// <summary>
        /// Add a new component to the user's PC configuration
        /// </summary>
        /// <param name="itemId">The component identifier</param>
        /// <param name="userId">The unique GUID identifier for the user</param>
        /// <returns>The summary view of the added component</returns>
        public virtual UserComponentSummary Create(int itemId, string userId)
        {          
            var userComponentSummaryItem = new UserComponentSummary
            {
                UserId = Guid.Parse(userId)
            };

            userComponentSummaryItem.ComponentItem = DbContext.Set<ComponentItem>().FirstOrDefault(x => x.ID == itemId);
            DbContext.UserComponentSummary.Add(userComponentSummaryItem);
            DbContext.SaveChanges();

            return userComponentSummaryItem;
        }

        /// <summary>
        /// Removes a component from the user's PC configuration
        /// </summary>
        /// <param name="id">The identifier for the component summary item.</param>
        public virtual void Delete(int id)
        {
            var userComponentSummaryItem = DbContext.UserComponentSummary.Find(id);

            if (userComponentSummaryItem != null)
            {
                DbContext.UserComponentSummary.Remove(userComponentSummaryItem);
                DbContext.SaveChanges();
            }         
        }

    }
}
