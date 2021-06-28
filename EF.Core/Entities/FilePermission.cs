using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Entities
{
    public class FilePermission:Entity
    {
        public int? FileId { get; set; }
        public int? UserId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }

        public virtual User User { get; set; }
        public virtual File File { get; set; }
    }
}
