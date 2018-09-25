using EF.ComponentData.Models;
using System.Collections.Generic;

namespace EF.ComponentData.Repositories
{
    public interface IRepository<T> where T : IBaseEntity
    {
        T FindById(object id);
        IList<T> FindAll();
    }
}
