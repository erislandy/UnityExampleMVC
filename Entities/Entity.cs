using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var obj1 = (Entity) obj;

            return this.Id == obj1.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
