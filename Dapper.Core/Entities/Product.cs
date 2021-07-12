using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities
{
    public class Product:Entity
    {
        public int MerchantId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Merchant Merchant { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
