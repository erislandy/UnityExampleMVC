using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;
using System.ComponentModel.DataAnnotations;

namespace UnityExampleMVC.Domain
{
    public class Product : Entity
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public double Amount { get; set; }
        public virtual Category Category { get; set; }
    }
}
