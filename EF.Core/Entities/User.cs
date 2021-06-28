using EF.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EF.Core
{
    public class User:Entity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public ICollection<DirectoryPermission> DirectoryPermissions { get; set; }
        public ICollection<FilePermission> FilePermissions { get; set; }
    }
}
