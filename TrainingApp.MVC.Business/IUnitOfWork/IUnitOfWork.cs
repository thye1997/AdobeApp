using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.Framework.Interfaces;

namespace TrainingApp.MVC.Business
{
   public interface IUnitOfWork
    {
        IRepository Repository { get; }

        int Save();
    }
}
