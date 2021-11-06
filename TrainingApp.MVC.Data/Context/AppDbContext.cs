using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TrainingApp.MVC.Entities;
using TrainingApp.MVC.Framework.Constants;

namespace TrainingApp.MVC.Data.Context
{
   public class AppDbContext : DbContext
    {
        public AppDbContext():base(ConstantConfigHelper.DBConnection.DbString)
        {

        }

        public DbSet<User> User { set; get; }

        public DbSet<Course> Course { set; get; }
    }
}
