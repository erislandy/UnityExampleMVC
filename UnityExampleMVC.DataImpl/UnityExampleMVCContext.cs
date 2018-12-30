using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using UnityExampleMVC.Domain;

namespace UnityExampleMVC.DataImpl
{
    public class UnityExampleMVCContext : DbContext
    {
        public UnityExampleMVCContext(): base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
