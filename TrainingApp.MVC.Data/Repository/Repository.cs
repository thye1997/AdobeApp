using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.Data.Context;
using TrainingApp.MVC.Framework.Interfaces;

namespace TrainingApp.MVC.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> exp = null) where TEntity : class, new()
        {
            IQueryable<TEntity> query = _appDbContext.Set<TEntity>();
            if (exp != null)
            {
                query.Where(exp);
            }
            return query;
        }

       public void Insert<TEntity>(TEntity entity) where TEntity : class, IBusinessEntity
        {
            _appDbContext.Set<TEntity>().Add(entity);
        }
    }
}
