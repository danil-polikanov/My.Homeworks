using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities
{
    public class Country:Entity
    {
        public int Country_Code { get; set; }
        public string Name { get; set; }
        public  ICollection<User> Users { get; set; }
        public  ICollection<Merchant> Merchants { get; set; }
    }
}
