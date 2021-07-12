using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities
{
   public class Order:Entity
    {
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public string OrderJson { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
