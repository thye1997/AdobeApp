using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrainingApp.Models;

namespace TrainingApp.Database.CodeFIrst
{

    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext(): base("CodeFirst")
        {
                
        }
        public DbSet<User> User { set; get; }

        public DbSet<Course> Course { set; get; }
    }
}