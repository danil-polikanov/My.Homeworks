using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities
{
    public class User:Entity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int? CountryCode { get; set; }
        public int? CountryId { get; set; }
        public virtual Country CountryCodes { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Order> Orders { get; set; }
        public virtual Merchant Merchant { get; set; }
    }
}
