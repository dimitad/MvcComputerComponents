using System.Collections.Generic;
using EF.ComponentData.Models;

namespace EF.ComponentData.Services
{
    public interface IComponentItemService
    {
        ComponentItem FindComponentById(int componentId);
        IList<ComponentItem> GetComponentItemsByCategoryCode(string categoryCode);
    }
}