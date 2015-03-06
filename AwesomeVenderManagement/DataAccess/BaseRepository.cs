using AwesomeVenderManagement.VendorDbContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AwesomeVenderManagement.DataAccess
{
    public abstract class BaseRepository<Entity> 
        : IRepository<Entity> where Entity : class
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IDbSet<Entity> _entitySet;
        protected BaseRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._entitySet = dbContext.Set<Entity>();

        }
        public Entity Save(Entity entity)
        {
           // _dbContext.Entry(entity).State = EntityState.Detached;

            this._entitySet.AsNoTracking<Entity>();

             this._entitySet.Add(entity);

             this._dbContext.SaveChanges();
             return entity;

        }


        public IEnumerable<Entity> GetAll()
        {
            return this._entitySet.ToList();
        }


        public void Delete(object id)
        {
            var currentEntity = this._entitySet.Find(id);

            if (currentEntity != null)
            {
                this._entitySet.Remove(currentEntity);

                this._dbContext.SaveChanges();
            }
        }


        public Entity Update(Entity entity)
        {
            _dbContext.Entry (entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }


        public Entity GetEntityById(object entityId)
        {
            return this._entitySet.Find(entityId);
        }


        public IEnumerable<Entity> Get(System.Linq.Expressions.Expression<Func<Entity, bool>> filter = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Entity> query = _entitySet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
    }
}