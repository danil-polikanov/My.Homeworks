using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Entities
{
    public class Directory : Entity
    {
        public int? ParentDirectoryId { get; set; }
        public string Title { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
    }
}
