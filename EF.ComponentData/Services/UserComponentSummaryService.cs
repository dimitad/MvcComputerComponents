using EF.ComponentData.Models;
using EF.ComponentData.Repositories;
using System.Collections.Generic;

namespace EF.ComponentData.Services
{
    /// <summary>
    /// Business layer service class for dealing with the component summary repository.
    /// </summary>
    public class UserComponentSummaryService
    {
        private readonly UserComponentSummaryRepository _userComponentSummaryRepository = new UserComponentSummaryRepository();

        /// <summary>
        /// Find all components selected by a user
        /// </summary>
        /// <param name="userId">User GUID</param>
        /// <returns>A collection representing the PC configuration user has selected</returns>
        public virtual IList<UserComponentSummary> FindComponentItemListByUser(string userId)
        {
            return _userComponentSummaryRepository.FindComponentItemListByUser(userId);
        }

        /// <summary>
        /// Add a component to the PC configuration
        /// </summary>
        /// <param name="itemId">Component identifier</param>
        /// <param name="userId">User GUID</param>
        /// <returns>Component summary model that was added</returns>
        public virtual UserComponentSummary AddUserComponentSummaryItem(int itemId, string userId)
        {
            return _userComponentSummaryRepository.Create(itemId, userId);
        }

        /// <summary>
        /// Remove a component from the PC configuration
        /// </summary>
        /// <param name="id">Identifier of the component summary view</param>
        public virtual void RemoveUserComponentSummaryItem(int id)
        {
            _userComponentSummaryRepository.Delete(id);           
        }
    }
}
