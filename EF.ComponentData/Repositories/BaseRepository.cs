using EF.ComponentData.DbContexts;
using EF.ComponentData.Models;
using System.Collections.Generic;
using System.Linq;

namespace EF.ComponentData.Repositories
{
    /// <summary>
    /// Base repository class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ComponentEntities DbContext { get; } = new ComponentEntities();

        public T FindById(object id)
        {
            using (var ctx = new ComponentEntities())
            {
                return ctx.Set<T>().Find(id);
            }
        }

        public IList<T> FindAll()
        {
            using (var ctx = new ComponentEntities())
            {
                return ctx.Set<T>().ToList();
            }
        }
    }
}
