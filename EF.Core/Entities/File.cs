using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core.Entities
{
    public class File: Entity
    {
        public int? DirectoryId {get;set;}

        public string Title { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }

        public virtual Directory Directories { get; set; }
        public ICollection<FilePermission> FilePermissions { get; set; }

    }
}
