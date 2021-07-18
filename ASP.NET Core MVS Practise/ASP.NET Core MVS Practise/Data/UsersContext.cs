using ASP.NET_Core_MVS_Practise.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVS_Practise.Data
{
    public class UsersContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }
    }
}
