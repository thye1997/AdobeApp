using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.Business;
using TrainingApp.MVC.Data.Context;
using TrainingApp.MVC.Framework.Interfaces;

namespace TrainingApp.MVC.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly IRepository _repository;
        public UnitOfWork(AppDbContext appDbContext, IRepository repository)
        {
            _context = appDbContext;
            _repository = new Repository(_context);
            
        }
        public IRepository Repository => _repository;


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
           return  _context.SaveChanges();
        }
    }
}
