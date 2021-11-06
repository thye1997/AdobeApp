using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp.MVC.Framework.Interfaces
{
   public interface IRepository
    {
        IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> exp) where TEntity : class, new();

        void Insert<TEntity>(TEntity entity) where TEntity : class, IBusinessEntity;
        
    }
}
