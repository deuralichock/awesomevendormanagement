using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeVenderManagement.DataAccess
{
    public interface IRepository<Entity> where Entity : class
    {
        Entity Save(Entity entity);
        IEnumerable<Entity> GetAll();

        void Delete(object id);

        Entity Update(Entity entity);

        Entity GetEntityById(object entityId);

        IEnumerable<Entity> Get(
                       Expression<Func<Entity, bool>> filter = null,
                       Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null,
                       string includeProperties = "");
    }
}

