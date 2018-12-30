using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;

namespace UnityExampleMVC.Domain
{
    public class Category : Entity
    {
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
