using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace VentilationEquipment
{
   public interface IRepository<TEntity> where TEntity:class
    {
        void Delete(TEntity entityToDelete);
        void Delete(object id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,string includeProperties = "");
        void Insert(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> GetAll();


    }
}
