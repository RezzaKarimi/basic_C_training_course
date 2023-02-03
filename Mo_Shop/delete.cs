using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;   

namespace Mo_Shop
{
    internal class delete : DbContext
    {
        public delete() : base("constr")
        {

        }

        public DbSet<mobile> d { get; set; }
    }
}
