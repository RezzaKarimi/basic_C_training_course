using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Mo_Shop
{
    internal class db : DbContext
    {
        public db() : base("constr")
        {
        }
        public DbSet<mobile> mob { get;  set; }
    }

}
    

