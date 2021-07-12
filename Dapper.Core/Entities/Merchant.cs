using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities
{
    public class Merchant:Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
